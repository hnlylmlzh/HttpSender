using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Threading;
using test.server.Auth;

namespace test.server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public string About(string a)
        {
            return $"Get {a}";
        }

        [HttpGet]
        public string Wait(string a)
        {
            Thread.Sleep(2300);
            return $"Get {a}";
        }

        [HttpPost]
        public string Contact(string b)
        {
            return $"Post {b}";
        }

        [HttpPut]
        public string TestPut(string c)
        {
            return $"Put {c}";
        }

        [HttpDelete]
        public string TestDelete(string d)
        {
            return $"Delete {d}";
        }

        [AuthTest]
        [HttpGet]
        public string TestAuth(string e)
        {
            return $"Auth {e}";
        }

        [HttpGet]
        public string Info(string username)
        {
            return $"Hello, {username}";
        }

        [HttpPost]
        public bool Login(string username,string password)
        {
            return username== "jim" && password == "123456";
        }

        [HttpPut]
        public string Update(string username, int age)
        {
            return $"{username}'s age is {age}";
        }

        [HttpDelete]
        public string Delete(string username, string year)
        {
            return $"{username}'s information in {year} has been deleted";
        }
    }
}
