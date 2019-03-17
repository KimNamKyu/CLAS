using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index(string cNo)
        {
            switch (cNo)
            {
                case "1":
                    ViewData["Title"] = "Notice";
                    ViewData["TitleName"] = "공지사항";
                    break;
                case "2":
                    ViewData["Title"] = "Coummnity";
                    ViewData["TitleName"] = "커뮤니티";
                    break;
                case "3":
                    ViewData["Title"] = "QnA";
                    ViewData["TitleName"] = "QnA";
                    break;
                default:
                    ViewData["Title"] = "오류";
                    ViewData["TitleName"] = "오류";
                    break;
            }
            ViewData["cNo"] = cNo;
            return View();
        }
        public IActionResult Detail(string bNo)
        {
            ViewData["bNo"] = bNo;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> TestSession()
        {
            // 참조 : https://github.com/aspnet/Docs/tree/master/aspnetcore/security/cookie-sharing/sample/CookieAuth.Core
            // 참조 : https://github.com/gilbutITbook/006824/tree/master/Chapter34/DotNetNote/src/DotNetNote
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin", ClaimValueTypes.String, "urn:net-core")
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Identity.Application");
            var authProperties = new AuthenticationProperties() { };
            //await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(ci), authProperties);
            await HttpContext.SignInAsync("Identity.Application", new ClaimsPrincipal(claimsIdentity), authProperties);
            return LocalRedirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Identity.Application");
            return LocalRedirect("/");
        }
    }
}