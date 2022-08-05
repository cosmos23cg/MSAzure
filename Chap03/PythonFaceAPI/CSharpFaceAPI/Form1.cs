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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CSharpFaceAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            string image_url = "https://storage.googleapis.com/www-cw-com-tw/article/202011/article-5fa78e6d8da7c.jpg";
            //image_url = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAG8HIc.img?h=630&w=1119&m=6&q=60&o=f&l=f&x=472&y=328"	//阿翔記者會
            //image_url = "https://www.nownews.com/wp-content/uploads/2019/08/1566376044-b9fe88e5bfaea24f2aaabc93b71a9bfd.jpg"		        //謝忻記者會

            HttpClient client = new HttpClient();

            using (var imgResponse = await client.GetAsync(image_url))
            {
                imgResponse.EnsureSuccessStatusCode();

                using (Stream inputStream = await imgResponse.Content.ReadAsStreamAsync())
                {
                    pictureBox1.Image = Image.FromStream(inputStream);
                }
            }

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "14f2a91916b6420f9b484c890d013732");

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            queryString["recognitionModel"] = "recognition_01";
            queryString["returnRecognitionModel"] = "false";
            queryString["detectionModel"] = "detection_01";

            var uri = "https://msit13200faceapi.cognitiveservices.azure.com/face/v1.0/detect?" + queryString;

            JObject data = new JObject
            {
                ["url"] = image_url
            };
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            string content = await response.Content.ReadAsStringAsync();

            dynamic faces = JsonConvert.DeserializeObject(content);
            foreach (var item in faces)
            {
                JObject face = item as JObject;
                int age = Convert.ToInt32(face["faceAttributes"]["age"]);
                string gender = Convert.ToString(face["faceAttributes"]["gender"]);
                JObject emotion = JObject.Parse(Convert.ToString(face["faceAttributes"]["emotion"]));
                float MaxEmotion = 0f;
                string MaxEmotionName = "";
                foreach (JProperty prop in emotion.Properties())
                {
                    float PropertyValue = float.Parse(emotion[prop.Name].ToString());
                    if (PropertyValue > MaxEmotion)
                    {
                        MaxEmotion = PropertyValue ;
                        MaxEmotionName=prop.Name;
                    }
                    
                }
                MessageBox.Show($"性別:{gender}, 年齡:{age}, 情緒:{MaxEmotionName}, 信心指數:{(MaxEmotion*100):n2}%");
            }            
        }
    }
}
