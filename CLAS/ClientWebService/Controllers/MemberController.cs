using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClientWebService.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Route("api/Login")]
        [HttpPost]
        public ArrayList select([FromForm]string id, [FromForm]string pwd)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@UserId", id);
            ht.Add("@UserPwd", pwd);
            DataBase db = new DataBase();
            ArrayList resultArray = db.GetList("UserLogon", ht);
            db.Close();
            Hashtable row = (Hashtable)resultArray[0];
            //int state = Convert.ToInt32(row["state"]);
            //string MemberName = row["MemberName"].ToString();
            //if (state > 0)
            //{
            //  ISession session = Request.HttpContext.Session;
            //  session.SetString("USER_LOGIN_KEY", MemberName);
            //  Console.WriteLine("USER_LOGIN_KEY : {0}", session.GetString("USER_LOGIN_KEY"));
            //  HttpContext.Session.SetString("USER_LOGIN_KEY", MemberName);
            //  Console.WriteLine("USER_LOGIN_KEY : {0}", HttpContext.Session.GetString("USER_LOGIN_KEY"));
            //}
            return resultArray;
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

        

        [Route("api/deleteMember")]
        [HttpPost]
        public string delete([FromForm]string mNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@mNo", mNo);
            DataBase db = new DataBase();
            if (db.NonQuery("Member_delete_proc", ht))
            {
                db.Close();
                return "1";
            }
            else
            {
                db.Close();
                return "0";
            }
        }

    }
}
