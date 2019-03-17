using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientWebService.Models;
using System.Collections;
using System.Data.SqlClient;

namespace ClientWebService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string state)
        {
            ViewData["state"] = state;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
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

        public IActionResult Login()
        {
            DataBase db = new DataBase();
            SqlDataReader sdr = db.Reader("Member_Info");
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i<sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            Hashtable row = (Hashtable)list[0];
            string userNo = row["MemberNo"].ToString();
            
            return View();
        }
    }
}
