using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace HttpSender
{
    public class Sender
    {
        private static HttpClient client = new HttpClient() { Timeout=TimeSpan.FromMilliseconds(2000)};

        public static void OAuth(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static string Get(string url)
        {
            HttpResponseMessage result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static string Post(string url,string content)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream memory = new MemoryStream(byteArray);
            StreamContent contentStream = new StreamContent(memory);
            contentStream.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            HttpResponseMessage result = client.PostAsync(url, contentStream).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static string Post(string url, Dictionary<string,string> content)
        {
            HttpResponseMessage result = client.PostAsync(url, new FormUrlEncodedContent(content)).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static string Put(string url)
        {
            HttpResponseMessage result = client.PutAsync(url, null).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static string Put(string url, Dictionary<string,string> content)
        {
            HttpResponseMessage result = client.PutAsync(url, new FormUrlEncodedContent(content)).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static string Delete(string url)
        {
            HttpResponseMessage result = client.DeleteAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
