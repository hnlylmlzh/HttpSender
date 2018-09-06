using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;

namespace Http.Messenger
{
    public class Pigeon
    {
        private static HttpClient client = new HttpClient();

        public string Get(string url)
        {
            HttpResponseMessage result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Post(string url,string content)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(content);
            MemoryStream memory = new MemoryStream(byteArray);
            StreamContent contentStream = new StreamContent(memory);
            contentStream.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            HttpResponseMessage result = client.PostAsync(url, contentStream).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Post(string url, Dictionary<string,string> content)
        {
            HttpResponseMessage result = client.PostAsync(url, new FormUrlEncodedContent(content)).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
