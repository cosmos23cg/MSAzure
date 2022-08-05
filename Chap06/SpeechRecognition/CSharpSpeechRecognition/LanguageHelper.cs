using Azure;
using Azure.AI.TextAnalytics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpeechRecognition
{
    public static class LanguageHelper
    {
        private static readonly string subscriptionKey = "9f27897171df49288002c4d8101b5373";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";
        private static readonly string location = "eastus";

        public async static Task<string> DetectLanguage(string text)
        {
            // Output languages are defined as parameters, input language detected.
            string route = "/detect?api-version=3.0";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage())
                {
                    // Build the request.
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri(endpoint + route);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                    request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                    // Send the request and get response.
                    HttpResponseMessage response = await client.SendAsync(request);
                    // Read response as a string.
                    string result = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(result);
                    JArray json = JArray.Parse(result);

                    return Convert.ToString(json[0]["language"]);
                }
            }
        }
        public async static Task<string> TranslateText(string text, string toLanguage)
        {
            // Input and output languages are defined as parameters.
            string route = $"/translate?api-version=3.0&from={await DetectLanguage(text)}&to={toLanguage}";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage())
                {
                    // Build the request.
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri(endpoint + route);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                    request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                    // Send the request and get response.
                    HttpResponseMessage response = await client.SendAsync(request);
                    // Read response as a string.
                    string result = await response.Content.ReadAsStringAsync();
                    JArray json = JArray.Parse(result);
                    return Convert.ToString(json[0]["translations"][0]["text"]);
                }
            }
        }
    }
}
