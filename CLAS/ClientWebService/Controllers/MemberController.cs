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
        [Route("select/Login")]
        [HttpPost]
        public ActionResult<ArrayList> select([FromForm] string spName, [FromForm]string id, [FromForm]string pwd)
        {
            Console.WriteLine("spName : {0}, id : {1}, pwd : {2}", spName, id, pwd);
            Hashtable ht = new Hashtable();

            ht.Add("@UserId", id);
            ht.Add("@UserPwd", pwd);
            DataBase db = new DataBase();
            ArrayList result = db.GetList(spName, ht);
            return result;
        }

        [Route("api/Register")]
        [HttpPost]
        public string Register([FromForm] string spName, [FromForm]string id, [FromForm]string pwd, [FromForm]string name)
        { 
            Hashtable ht = new Hashtable();
            ht.Add("@UserId", id);
            ht.Add("@UserPwd", pwd);
            ht.Add("@UserName", name);
            DataBase db = new DataBase();
            if (db.NonQuery(spName, ht))
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
