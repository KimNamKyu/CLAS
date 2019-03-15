using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Route("api/Login")]
        [HttpPost]
        public int select([FromForm]string id, [FromForm]string pwd)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@UserId", id);
            ht.Add("@UserPwd", pwd);
            DataBase db = new DataBase();
            int result = db.NonQuerys("UserLogon", ht);
            HttpContext.Session.SetInt32("USER_LOGIN_KEY", result);
            db.Close();
            return result;
        }

        [Route("api/Register")]
        [HttpPost]
        public int Register([FromForm]string id, [FromForm]string pwd, [FromForm]string name)
        { 
            Hashtable ht = new Hashtable();
            ht.Add("@UserId", id);
            ht.Add("@UserPwd", pwd);
            ht.Add("@UserName", name);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Sign_up", ht);
            db.Close();
            return result;
        }
    }
}
