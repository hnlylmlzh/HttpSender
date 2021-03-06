﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace HttpSender
{
    public class Sender
    {
        private static HttpClient client = new HttpClient();

        /*
        public static void OAuth(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        */

        public static string Get(string url)
        {
            url = FixUrl(url);
            Task<HttpResponseMessage> GetTask = client.GetAsync(url);
            try
            {
                return RunTask(GetTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Post(string url, string content)
        {
            url = FixUrl(url);
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream memory = new MemoryStream(byteArray);
            StreamContent contentStream = new StreamContent(memory);
            contentStream.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            Task<HttpResponseMessage> PostTask = client.PostAsync(url, contentStream);
            try
            {
                return RunTask(PostTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Post(string url, Dictionary<string, string> content)
        {
            url = FixUrl(url);
            Task<HttpResponseMessage> PostTask = client.PostAsync(url, new FormUrlEncodedContent(content));
            try
            {
                return RunTask(PostTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Put(string url)
        {
            url = FixUrl(url);
            Task<HttpResponseMessage> PutTask = client.PutAsync(url, null);
            try
            {
                return RunTask(PutTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Put(string url, Dictionary<string, string> content)
        {
            url = FixUrl(url);
            Task<HttpResponseMessage> PutTask = client.PutAsync(url, new FormUrlEncodedContent(content));
            try
            {
                return RunTask(PutTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Delete(string url)
        {
            url = FixUrl(url);
            Task<HttpResponseMessage> DeleteTask = client.DeleteAsync(url);
            try
            {
                return RunTask(DeleteTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string RunTask(Task<HttpResponseMessage> task)
        {
            bool timeout;
            try
            {
                timeout = task.Wait(5000);
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                throw e;
            }
            if (timeout == false)
            {
                throw new TimeoutException("Timeout");
            }
            else
            {
                HttpContent result = task.Result.Content;
                return result.ReadAsStringAsync().Result;
            }
        }

        private static string FixUrl(string url)
        {
            if (url.StartsWith("http", StringComparison.OrdinalIgnoreCase) == false)
            {
                return "http://" + url;
            }
            else
            {
                return url;
            }
        }
    }
}
