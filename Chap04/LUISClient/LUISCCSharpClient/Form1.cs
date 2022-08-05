using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUISCCSharpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLUIS_Click(object sender, EventArgs e)
        {
            string EndpointUrl = "https://mymlluis.cognitiveservices.azure.com";
            string AppId = "0525bf51-3261-45b0-b15c-47d03bbb6443";
            string SubscriptionKey = "9183df3a5c8d40b29b9b9932c51499c3";
            string query = txtUtterance.Text;

            string url = $"{EndpointUrl}/luis/prediction/v3.0/apps/{AppId}/slots/production/predict?subscription-key={SubscriptionKey}&verbose=true&show-all-intents=true&log=true&query={query}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();

            JObject json = JsonConvert.DeserializeObject(result) as JObject;

            JObject prediction = json["prediction"] as JObject;
            string topIntent = Convert.ToString(prediction["topIntent"]);
            float score = Convert.ToSingle(prediction["intents"][topIntent]["score"]);

            MessageBox.Show($"Intent:{topIntent}, 信心指數:{score * 100:N2}%");
        }
    }
}
