using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CSharpContentModerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnImageContentModerator_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "69feb4ce61494784af0143187e9430e1");

            // Request parameters
            queryString["CacheImage"] = "true";
            var uri = "https://mymlcontentmoderator.cognitiveservices.azure.com/contentmoderator/moderate/v1.0/ProcessImage/Evaluate?" + queryString;

            JObject data = new JObject
            {
                ["DataRepresentation"]="URL",
                ["Value"]="https://moderatorsampleimages.blob.core.windows.net/samples/sample2.jpg",
                //["Value"]="https://img.ltn.com.tw/Upload/news/600/2018/05/23/2435395_4.jpg",
            };

            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            string content = response.Content.ReadAsStringAsync().Result;

            JObject result = JsonConvert.DeserializeObject(content) as JObject;
            //MessageBox.Show(Convert.ToString(result));

            bool isAdult = Convert.ToBoolean(result["IsImageAdultClassified"]);
            bool isRacy = Convert.ToBoolean(result["IsImageRacyClassified"]);

            MessageBox.Show($"成人:{isAdult}, 種族:{isRacy}");
        }

        private async void btnTextContentModeratr_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "69feb4ce61494784af0143187e9430e1");

            // Request parameters
            queryString["autocorrect"] = "true";
            queryString["PII"] = "true";
            queryString["classify"] = "true";
            queryString["language"] = "eng";

            var uri = "https://mymlcontentmoderator.cognitiveservices.azure.com/contentmoderator/moderate/v1.0/ProcessText/Screen?" + queryString;

            string str= "Kiss my ass";

            StringContent stringContent = new StringContent(str, Encoding.UTF8, "text/plain");
            HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            string content = response.Content.ReadAsStringAsync().Result;

            JObject result = JsonConvert.DeserializeObject(content) as JObject;
            //MessageBox.Show(Convert.ToString(result));

            JObject classification = JObject.Parse(Convert.ToString(result["Classification"]));
            float MaxConfidence = 0f;
            string MaxConfidenceName = "";
            foreach (JProperty prop in classification.Properties())
            {
                if (prop.Name.StartsWith("Category"))
                {
                    float PropertyValue = float.Parse(classification[prop.Name]["Score"].ToString());
                    if (PropertyValue > MaxConfidence)
                    {
                        MaxConfidence = PropertyValue;
                        MaxConfidenceName = prop.Name;
                    }
                }
            }
            MessageBox.Show($"{GetDisplayName(MaxConfidenceName)}:{MaxConfidence:N2}");
        }

        private string GetDisplayName(string maxConfidenceName)
        {
            string DisplayName = "";
            switch (maxConfidenceName)
            {
                case "Category1":
                    DisplayName = "成人內容";
                    break;
                case "Category2":
                    DisplayName = "性暗示";
                    break;
                case "Category3":
                    DisplayName = "冒犯性";
                    break;
            }
            return DisplayName;
        }
    }
}
