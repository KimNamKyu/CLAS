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
      
        public async Task<IActionResult> Index()
        {
            ArrayList list = new ArrayList();
            HttpClient client = new HttpClient();
            var res = await client.GetAsync("http://localhost/api/Data");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<ArrayList>(result);
                Console.WriteLine(list);
            }
            return View(list);
        }

        private static async void Indexs()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost/api/Data");
                Console.WriteLine(result);
            }
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            //List<User> users = new List<User>();
            //HttpClient client = new HttpClient();
            //var res = await client.GetAsync("http://localhost/api/Data");

            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    users = JsonConvert.DeserializeObject<List<User>>(result);

            //    Console.WriteLine(users);
            //}
            //Console.WriteLine("failes!!!=====");

            //WebClient client = new WebClient();
            //string Url = "http://localhost:5000/api/Data";
            //Stream result = client.OpenRead(Url);
            //StreamReader sr = new StreamReader(result);
            //string str = sr.ReadToEnd();
            //List<User> users = new List<User>();
            //users = JsonConvert.DeserializeObject<List<User>>(str);
            List<User> users = new List<User>();

            using (WebClient client = new WebClient())
            {
                string Url = "http://localhost:5000/api/Data";
                using (StreamReader sr = new StreamReader(client.OpenRead(Url)))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }
            }

            return View(users);
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
