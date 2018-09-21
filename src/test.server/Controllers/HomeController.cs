using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
    }
}
