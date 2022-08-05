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

namespace CSharpCustomVision
{
    public partial class frmCustomVisionClient : Form
    {
        public frmCustomVisionClient()
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
            //string image_url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyHd2Hz7b-bVUWag1uY8MqwvzJzAJyiWKYYBXkkgeDQxdHqjGl122RRjyyJ3n1DwT7WYJzkaBULPT3BYow9HguGVAGBdblgBz9Xg&usqp=CAU&ec=45732304";

            HttpClient client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Prediction-Key", "338d9f52404e46e2bea57cbc499fa707");

            // Request url
            var uri = "https://msit13300customvision-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/c82c65c9-288b-444b-a9a4-f7006d91671e/classify/iterations/Iteration1/image";

            HttpResponseMessage response = null;

            using (var content = new ByteArrayContent(ImageData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);

                string result = await response.Content.ReadAsStringAsync();
                //MessageBox.Show(result);
                dynamic json = JsonConvert.DeserializeObject(result);
                JObject data = json as JObject;
                double Confidence = Convert.ToDouble(data["predictions"][0]["probability"]);
                string Tag = Convert.ToString(data["predictions"][0]["tagName"]);
                MessageBox.Show($"類別:{Tag}, 信心指數:{(Confidence*100):f2}%");
            }
        }    
    }
}
