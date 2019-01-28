using System;
using System.Collections.Generic;
using System.Text;
using HttpSender;
using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Performance.Test
{
    public class Test
    {
        [Benchmark]
        public void start()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                string Response = string.Empty;
                for (int i = 0; i < 100000; i++)
                {
                    Response = Sender.Get("localhost/apiserver/api/test");
                    Response = Sender.Post("localhost/apiserver/api/test", string.Empty);
                    Dictionary<string, string> content = new Dictionary<string, string>();
                    Response = Sender.Post("localhost/apiserver/api/test", content);
                }
            });
            tasks[1] = Task.Run(() =>
            {
                string Response = string.Empty;
                for (int i = 0; i < 100000; i++)
                {
                    Response = Sender.Get("localhost/apiserver/api/test");
                    Response = Sender.Post("localhost/apiserver/api/test", string.Empty);
                    Dictionary<string, string> content = new Dictionary<string, string>();
                    Response = Sender.Post("localhost/apiserver/api/test", content);
                }
            });
            tasks[2] = Task.Run(() =>
            {
                string Response = string.Empty;
                for (int i = 0; i < 100000; i++)
                {
                    Response = Sender.Get("localhost/apiserver/api/test");
                    Response = Sender.Post("localhost/apiserver/api/test", string.Empty);
                    Dictionary<string, string> content = new Dictionary<string, string>();
                    Response = Sender.Post("localhost/apiserver/api/test", content);
                }
            });
            Task.WaitAll(tasks);
        }
    }
}
