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
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CSharpVisionAPI
{
    public partial class frmRemote : Form
    {
        public frmRemote()
        {
            InitializeComponent();
        }

        private async void btnAnalyzed_Click(object sender, EventArgs e)
        {
            string image_url = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F47%2F2020%2F08%2F09%2Fpersian-cat-walking-ledge-660545539-2000.jpg";
            HttpClient client = new HttpClient();
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            using (var imgResponse = await client.GetAsync(image_url))
            {
                imgResponse.EnsureSuccessStatusCode();
                using (Stream inputStream = await imgResponse.Content.ReadAsStreamAsync())
                {
                    pictureBox1.Image = Image.FromStream(inputStream);
                }
            }

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fd9701c6d2214f4cb5e820a6d221d300");

            // Request parameters
            queryString["visualFeatures"] = "Categories,Description";
            queryString["details"] = "Landmarks";
            queryString["language"] = "en";

            var uri = "https://msit13300visionservice.cognitiveservices.azure.com/vision/v3.2/analyze?" + queryString;

            JObject data = new JObject
            {
                ["url"] = image_url
            };
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            string content = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(content);
            
            JObject description = result as JObject;
            string text = Convert.ToString(description["description"]["captions"][0]["text"]).Capitalize();
            float confidence = Convert.ToSingle(description["description"]["captions"][0]["confidence"]);

            lbDescription.Text = $"{text}(信心指數:{confidence*100:n2}%)";
        }
    }
}
