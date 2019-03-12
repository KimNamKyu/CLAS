using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CLAsite.Models;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CLAsite.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
