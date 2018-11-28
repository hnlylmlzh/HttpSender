using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpSender
{
    public class Sender
    {
        private static HttpClient client = new HttpClient();

        public static void OAuth(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static string Get(string url)
        {
            Task<HttpResponseMessage> GetTask = client.GetAsync(url);
            bool timeout;
            try
            {
                timeout = GetTask.Wait(5000);
            }
            catch(Exception e)
            {
                if(e is AggregateException && e.InnerException != null)
                {
                    throw e.InnerException;
                }
                else
                {
                    throw e;
                }
            }
            if (timeout == false)
            {
                throw new TimeoutException("Timeout");
            }
            else
            {
                HttpContent result = GetTask.Result.Content;
                return result.ReadAsStringAsync().Result;
            }
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
