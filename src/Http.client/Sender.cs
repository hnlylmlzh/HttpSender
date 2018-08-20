using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Http.client
{
    public class Sender
    {
        private static HttpClient client = new HttpClient();

        public static string Get(string url)
        {
            HttpResponseMessage result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
