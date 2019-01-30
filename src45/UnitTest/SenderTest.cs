using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpSender;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Net.Sockets;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void GetTest()
        {
            string getResult = Sender.Get("http://localhost/mvcserver/home/about?a=1");
            Assert.AreEqual("Get 1", getResult);
            getResult = Sender.Get("http://localhost/apiserver/api/values");
            Assert.AreEqual("[\"value1\",\"value2\"]", getResult);
            getResult = Sender.Get("https://www.baidu.com");
            Assert.IsTrue(getResult.Contains("<title>百度一下，你就知道</title>"));
            getResult = Sender.Get("www.baidu.com");
            Assert.IsTrue(getResult.Contains("<title>百度一下，你就知道</title>"));
            getResult = Sender.Get("baidu.com");
            Assert.IsTrue(getResult.Length > 0);
            getResult = Sender.Get("Http://localhost/apiserver/api/test");
            Assert.AreEqual("\"Hello world\"", getResult);
        }

        [TestMethod]
        public void GetExceptionTest()
        {
            Assert.ThrowsException<SocketException>(() => Sender.Get("http://localhost:4900"));
            Assert.ThrowsException<TimeoutException>(() => Sender.Get("http://localhost/mvcserver/home/wait?a=2"));
            Assert.ThrowsException<AuthenticationException>(() => Sender.Get("https://localhost/sslserver/api/values"));
        }

        [TestMethod]
        public void PostTest()
        {
            string postResult = Sender.Post("http://localhost/mvcserver/home/contact", "b=2");
            Assert.AreEqual("Post 2", postResult);
            postResult = Sender.Post("http://localhost/apiserver/api/values", "value=asd");
            Assert.AreEqual("\"asd\"", postResult);
            postResult = Sender.Post("http://localhost/apiserver/api/values", "value=汉字");
            Assert.AreEqual("\"汉字\"", postResult);
            postResult = Sender.Post("127.0.0.1/apiserver/api/values", "value=春天");
            Assert.AreEqual("\"春天\"", postResult);
            postResult = Sender.Post("HTTP://127.0.0.1/apiserver/api/test", "");
            Assert.AreEqual("\"Hello world\"", postResult);
        }

        [TestMethod]
        public void PostDictionaryTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = Sender.Post("http://localhost/mvcserver/home/contact", test);
            Assert.AreEqual("Post 3", postResult);
            postResult = Sender.Post("HTTP://127.0.0.1/apiserver/api/test", new Dictionary<string, string> { });
            Assert.AreEqual("\"Hello world\"", postResult);
        }

        [TestMethod]
        public void PostExceptionTest()
        {
            Assert.ThrowsException<SocketException>(() => Sender.Post("http://localhost:4900", "b=2"));
            Assert.ThrowsException<SocketException>(() => Sender.Post("http://localhost:4900", new Dictionary<string, string> { { "a", "5" } }));
            Assert.ThrowsException<TimeoutException>(() => Sender.Post("http://localhost/mvcserver/home/waitpost", "a=3"));
            Assert.ThrowsException<TimeoutException>(() => Sender.Post("http://localhost/mvcserver/home/waitpost", new Dictionary<string, string> { { "a", "5" } }));
        }

        [TestMethod]
        public void PutUrlTest()
        {
            string putResult = Sender.Put("http://localhost/mvcserver/home/testput?c=4");
            Assert.AreEqual("Put 4", putResult);
        }

        [TestMethod]
        public void PutTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "c", "5" } };
            string putResult = Sender.Put("http://localhost/mvcserver/home/testput", test);
            Assert.AreEqual("Put 5", putResult);
            Dictionary<string, string> test0 = new Dictionary<string, string> { { "c", "100" } };
            string putResult0 = Sender.Put("localhost/mvcserver/home/testput", test0);
            Assert.AreEqual("Put 100", putResult0);
        }

        [TestMethod]
        public void PutExceptionTest()
        {
            Assert.ThrowsException<SocketException>(() => Sender.Put("http://localhost:4900?c=4"));
            Assert.ThrowsException<SocketException>(() => Sender.Put("http://localhost:4900", new Dictionary<string, string> { { "a", "5" } }));
            Assert.ThrowsException<TimeoutException>(() => Sender.Put("http://localhost/mvcserver/home/waitput?c=3"));
            Assert.ThrowsException<TimeoutException>(() => Sender.Put("http://localhost/mvcserver/home/waitput", new Dictionary<string, string> { { "a", "5" } }));
        }

        [TestMethod]
        public void DeleteTest()
        {
            string deleteResult = Sender.Delete("http://localhost/mvcserver/home/testdelete?d=6");
            Assert.AreEqual("Delete 6", deleteResult);
            deleteResult = Sender.Delete("127.0.0.1/mvcserver/home/testdelete?d=6");
            Assert.AreEqual("Delete 6", deleteResult);
        }

        [TestMethod]
        public void DeleteExceptionTest()
        {
            Assert.ThrowsException<SocketException>(() => Sender.Delete("http://localhost:4900?d=5"));
            Assert.ThrowsException<TimeoutException>(() => Sender.Delete("http://localhost/mvcserver/home/waitdelete?d=5"));
        }

        /*
        [TestMethod]
        public void AuthTest()
        {
            string result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.AreNotEqual("Auth 7", result);
            Sender.OAuth("test");
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.AreEqual("Auth 7", result);
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=8");
            Assert.AreEqual("Auth 8", result);
            Sender.OAuth("test1");
            result = Sender.Get("http://localhost/mvcserver/home/testauth?e=7");
            Assert.AreNotEqual("Auth 7", result);
        }
        */

        [TestMethod]
        public void DemoTest()
        {
            string Response = string.Empty;
            Response = Sender.Get("http://localhost/mvcserver/home/info?username=jim");
            Assert.AreEqual("Hello, jim", Response);
            Response = Sender.Post("http://localhost/mvcserver/home/login", "username=jim&password=123456");
            Assert.AreEqual("true", Response.ToLower());
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
              { "username", "jim" },
              { "password", "123456" }
            };
            Response = Sender.Post("http://localhost/mvcserver/home/login", LoginInfo);
            Assert.AreEqual("true", Response.ToLower());
            Response = Sender.Put("http://localhost/mvcserver/home/update?username=jim&age=15");
            Assert.AreEqual("jim's age is 15", Response);
            Dictionary<string, string> UpdateInfo = new Dictionary<string, string>
            {
                { "username", "jim" },
                { "age" , "15"}
            };
            Response = Sender.Put("http://localhost/mvcserver/home/update", UpdateInfo);
            Assert.AreEqual("jim's age is 15", Response);
            Response = Sender.Delete("http://localhost/mvcserver/home/delete?username=jim&year=2011");
            Assert.AreEqual("jim's information in 2011 has been deleted", Response);
        }
    }
}
