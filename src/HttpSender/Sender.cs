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

        private string token;
        public string Token
        {
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    client.DefaultRequestHeaders.Remove("Bearer");
                }
                token = value;
            }
        }

        private void AddOAuthToken()
        {
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public string Get(string url)
        {
            AddOAuthToken();
            HttpResponseMessage result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Post(string url,string content)
        {
            AddOAuthToken();
            byte[] byteArray = Encoding.ASCII.GetBytes(content);
            MemoryStream memory = new MemoryStream(byteArray);
            StreamContent contentStream = new StreamContent(memory);
            contentStream.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            HttpResponseMessage result = client.PostAsync(url, contentStream).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Post(string url, Dictionary<string,string> content)
        {
            AddOAuthToken();
            HttpResponseMessage result = client.PostAsync(url, new FormUrlEncodedContent(content)).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Put(string url)
        {
            AddOAuthToken();
            HttpResponseMessage result = client.PutAsync(url, null).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Put(string url, Dictionary<string,string> content)
        {
            AddOAuthToken();
            HttpResponseMessage result = client.PutAsync(url, new FormUrlEncodedContent(content)).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Delete(string url)
        {
            AddOAuthToken();
            HttpResponseMessage result = client.DeleteAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
