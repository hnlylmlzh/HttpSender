using System;
using System.Collections.Generic;
using System.Text;
using HttpSender;
using BenchmarkDotNet.Attributes;

namespace Performance.Test
{
    public class Test
    {
        [Benchmark]
        public void start()
        {
            string Response = string.Empty;
            Response = Sender.Get("http://localhost:5000/home/info?username=jim");
            Response = Sender.Post("http://localhost:5000/home/login", "username=jim&password=123456");
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
              { "username", "jim" },
              { "password", "123456" }
            };
            Response = Sender.Post("http://localhost:5000/home/login", LoginInfo);
            Response = Sender.Put("http://localhost:5000/home/update?username=jim&age=15");
            Dictionary<string, string> UpdateInfo = new Dictionary<string, string>
            {
                { "username", "jim" },
                { "age" , "15"}
            };
            Response = Sender.Put("http://localhost:5000/home/update", UpdateInfo);
            Response = Sender.Delete("http://localhost:5000/home/delete?username=jim&year=2011");
        }
    }
}
