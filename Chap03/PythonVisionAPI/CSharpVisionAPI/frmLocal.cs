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
    public partial class frmLocal : Form
    {
        public frmLocal()
        {
            InitializeComponent();
        }

        byte[] ImageData=null;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                ImageData = File.ReadAllBytes(openFileDialog1.FileName);
            }    
        }

        private async void btnAnalyzed_Click(object sender, EventArgs e)
        {
            if(ImageData !=null)
            {
                HttpClient client = new HttpClient();
                NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fd9701c6d2214f4cb5e820a6d221d300");

                // Request parameters
                queryString["visualFeatures"] = "Categories,Description";
                queryString["details"] = "Landmarks";
                queryString["language"] = "en";

                var uri = "https://msit13300visionservice.cognitiveservices.azure.com/vision/v3.2/analyze?" + queryString;

                using (ByteArrayContent ImageContent = new ByteArrayContent(ImageData))
                {
                    ImageContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    HttpResponseMessage response = await client.PostAsync(uri, ImageContent);
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(content);

                    JObject description = result as JObject;
                    string text = Convert.ToString(description["description"]["captions"][0]["text"]).Capitalize();
                    float confidence = Convert.ToSingle(description["description"]["captions"][0]["confidence"]);

                    lbDescription.Text = $"{text}(信心指數:{confidence * 100:n2}%)";
                }
            }
        }
    }
}
