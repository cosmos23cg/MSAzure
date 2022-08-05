using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CSharpVisionAPI
{
    public partial class frmReadAPI : Form
    {
        public frmReadAPI()
        {
            InitializeComponent();
        }

        byte[] ImageData = null;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                ImageData = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }

        private async void btnAnalyzed_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ef47fdffad134aa3b81d70f1294c19ae");

            // Request parameters
            queryString["language"] = "en";
            var uri = "https://southcentralus.api.cognitive.microsoft.com/vision/v3.2/read/analyze?" + queryString;

            HttpResponseMessage response=null;

            using (var content = new ByteArrayContent(ImageData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);

                bool poll = true;
                while (poll)
                {
                    HttpResponseMessage response_final = await client.GetAsync(response.Headers.GetValues("Operation-Location").First());
                    JObject result = JsonConvert.DeserializeObject(await response_final.Content.ReadAsStringAsync()) as JObject;
                    string status = Convert.ToString(result["status"]);
                    if (status == "succeeded")
                    {
                        lbDetectedText.Text = Convert.ToString(result["analyzeResult"]["readResults"][0]["lines"][0]["text"]);
                        poll = false;
                    }
                    else if(status == "failed")
                    {
                        poll = false;
                    }
                    Text = status;
                }
            }
        }
    }
}
