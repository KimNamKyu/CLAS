using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notice()
        {
            return View();
        }

        public IActionResult Board()
        {
            return View();
        }

        public IActionResult QnA()
        {
            return View();
        }

    }
}