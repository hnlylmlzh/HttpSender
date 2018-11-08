using System;
using Xunit;
using HttpSender;
using System.Collections.Generic;

namespace HttpSender.Test
{
    public class SenderTest
    {
        [Fact]
        public void GetTest()
        {
            string getResult = Sender.Get("http://localhost:5000/home/about?a=1");
            Assert.Equal("Get 1",getResult);
            getResult = Sender.Get("http://localhost:6000/api/values");
            Assert.Equal("[\"value1\",\"value2\"]", getResult);
        }

        [Fact]
        public void PostTest()
        {
            string postResult = Sender.Post("http://localhost:5000/home/contact", "b=2");
            Assert.Equal("Post 2", postResult);
            postResult = Sender.Post("http://localhost:6000/api/values", "value=asd");
            Assert.Equal("asd", postResult);
            postResult = Sender.Post("http://localhost:6000/api/values", "value=汉字");
            Assert.Equal("汉字", postResult);
        }

        [Fact]
        public void PostDictionaryTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = Sender.Post("http://localhost:5000/home/contact", test);
            Assert.Equal("Post 3", postResult);
        }

        [Fact]
        public void PutUrlTest()
        {
            string putResult = Sender.Put("http://localhost:5000/home/testput?c=4");
            Assert.Equal("Put 4", putResult);
        }

        [Fact]
        public void PutTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "c", "5" } };
            string putResult = Sender.Put("http://localhost:5000/home/testput", test);
            Assert.Equal("Put 5", putResult);
        }

        [Fact]
        public void DeleteTest()
        {
            string deleteResult = Sender.Delete("http://localhost:5000/home/testdelete?d=6");
            Assert.Equal("Delete 6", deleteResult);
        }

        [Fact]
        public void WaitTest()
        {
            Assert.Throws<AggregateException>(()=>Sender.Get("http://localhost:5000/home/wait?a=1"));
        }

        [Fact]
        public void AuthTest()
        {
            string result = Sender.Get("http://localhost:5000/home/testauth?e=7");
            Assert.NotEqual("Auth 7", result);
            Sender.OAuth("test");
            result = Sender.Get("http://localhost:5000/home/testauth?e=7");
            Assert.Equal("Auth 7", result);
            result = Sender.Get("http://localhost:5000/home/testauth?e=8");
            Assert.Equal("Auth 8", result);
            Sender.OAuth("test1");
            result = Sender.Get("http://localhost:5000/home/testauth?e=7");
            Assert.NotEqual("Auth 7", result);
        }

        [Fact]
        public void DemoTest()
        {
            string Response = string.Empty;
            Response = Sender.Get("http://localhost:5000/home/info?username=jim");
            Assert.Equal("Hello, jim",Response);
            Response = Sender.Post("http://localhost:5000/home/login", "username=jim&password=123456");
            Assert.Equal("true", Response.ToLower());
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
              { "username", "jim" },
              { "password", "123456" }
            };
            Response = Sender.Post("http://localhost:5000/home/login", LoginInfo);
            Assert.Equal("true", Response.ToLower());
            Response = Sender.Put("http://localhost:5000/home/update?username=jim&age=15");
            Assert.Equal("jim's age is 15",Response);
            Dictionary<string, string> UpdateInfo = new Dictionary<string, string>
            {
                { "username", "jim" },
                { "age" , "15"}
            };
            Response = Sender.Put("http://localhost:5000/home/update", UpdateInfo);
            Assert.Equal("jim's age is 15", Response);
            Response = Sender.Delete("http://localhost:5000/home/delete?username=jim&year=2011");
            Assert.Equal("jim's information in 2011 has been deleted",Response);
        }
    }
}
