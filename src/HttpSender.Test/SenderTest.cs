using System;
using Xunit;
using HttpSender;
using System.Collections.Generic;
using System.Net.Http;

namespace HttpSender.Test
{
    public class SenderTest
    {
        [Fact]
        public void GetTest()
        {
            string getResult = Sender.Get("http://localhost/mvcserver/home/about?a=1");
            Assert.Equal("Get 1",getResult);
            getResult = Sender.Get("http://localhost/apiserver/api/values");
            Assert.Equal("[\"value1\",\"value2\"]", getResult);
        }

        [Fact]
        public void GetExceptionTest()
        {
            Assert.Throws<HttpRequestException>(() => Sender.Get("http://localhost:4900"));
            Assert.Throws<TimeoutException>(() => Sender.Get("http://localhost/mvcserver/home/wait?a=2"));
        }

        [Fact]
        public void PostTest()
        {
            string postResult = Sender.Post("http://localhost/mvcserver/home/contact", "b=2");
            Assert.Equal("Post 2", postResult);
            postResult = Sender.Post("http://localhost/apiserver/api/values", "value=asd");
            Assert.Equal("\"asd\"", postResult);
            postResult = Sender.Post("http://localhost/apiserver/api/values", "value=汉字");
            Assert.Equal("\"汉字\"", postResult);
        }

        [Fact]
        public void PostDictionaryTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = Sender.Post("http://localhost/mvcserver/home/contact", test);
            Assert.Equal("Post 3", postResult);
        }

        [Fact]
        public void PostExceptionTest()
        {
            Assert.Throws<HttpRequestException>(() => Sender.Post("http://localhost:4900", "b=2"));
            Assert.Throws<HttpRequestException>(() => Sender.Post("http://localhost:4900", new Dictionary<string, string> { { "a", "5" } }));
            Assert.Throws<TimeoutException>(() => Sender.Post("http://localhost/mvcserver/home/waitpost", "a=3"));
            Assert.Throws<TimeoutException>(() => Sender.Post("http://localhost/mvcserver/home/waitpost", new Dictionary<string, string> { { "a", "5" } }));
        }

        [Fact]
        public void PutUrlTest()
        {
            string putResult = Sender.Put("http://localhost/mvcserver/home/testput?c=4");
            Assert.Equal("Put 4", putResult);
        }

        [Fact]
        public void PutTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "c", "5" } };
            string putResult = Sender.Put("http://localhost/mvcserver/home/testput", test);
            Assert.Equal("Put 5", putResult);
        }

        [Fact]
        public void PutExceptionTest()
        {
            Assert.Throws<HttpRequestException>(() => Sender.Put("http://localhost:4900?c=4"));
            Assert.Throws<HttpRequestException>(() => Sender.Put("http://localhost:4900", new Dictionary<string, string> { { "a", "5" } }));
            Assert.Throws<TimeoutException>(() => Sender.Put("http://localhost/mvcserver/home/waitput?c=3"));
            Assert.Throws<TimeoutException>(() => Sender.Put("http://localhost/mvcserver/home/waitput", new Dictionary<string, string> { { "a", "5" } }));
        }

        [Fact]
        public void DeleteTest()
        {
            string deleteResult = Sender.Delete("http://localhost/mvcserver/home/testdelete?d=6");
            Assert.Equal("Delete 6", deleteResult);
        }

        [Fact]
        public void DeleteExceptionTest()
        {
            Assert.Throws<HttpRequestException>(() => Sender.Delete("http://localhost:4900?d=5"));
            Assert.Throws<TimeoutException>(() => Sender.Delete("http://localhost/mvcserver/home/waitdelete?d=5"));
        }


        [Fact]
        public void AuthTest()
        {
            string result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.NotEqual("Auth 7", result);
            Sender.OAuth("test");
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.Equal("Auth 7", result);
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=8");
            Assert.Equal("Auth 8", result);
            Sender.OAuth("test1");
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.NotEqual("Auth 7", result);
        }

        [Fact]
        public void DemoTest()
        {
            string Response = string.Empty;
            Response = Sender.Get("http://localhost/mvcserver/home/info?username=jim");
            Assert.Equal("Hello, jim",Response);
            Response = Sender.Post("http://localhost/mvcserver/home/login", "username=jim&password=123456");
            Assert.Equal("true", Response.ToLower());
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
              { "username", "jim" },
              { "password", "123456" }
            };
            Response = Sender.Post("http://localhost/mvcserver/home/login", LoginInfo);
            Assert.Equal("true", Response.ToLower());
            Response = Sender.Put("http://localhost/mvcserver/home/update?username=jim&age=15");
            Assert.Equal("jim's age is 15",Response);
            Dictionary<string, string> UpdateInfo = new Dictionary<string, string>
            {
                { "username", "jim" },
                { "age" , "15"}
            };
            Response = Sender.Put("http://localhost/mvcserver/home/update", UpdateInfo);
            Assert.Equal("jim's age is 15", Response);
            Response = Sender.Delete("http://localhost/mvcserver/home/delete?username=jim&year=2011");
            Assert.Equal("jim's information in 2011 has been deleted",Response);
        }
    }
}
