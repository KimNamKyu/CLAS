﻿using System;
using System.Collections;
using ClientWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    [ApiController]
    public class NoteAPIController : ControllerBase
    {
        [Route("select/Note")]
        [HttpPost]
        public ActionResult<ArrayList> select([FromForm] string spName, [FromForm]string param, [FromForm]string pNo)
        {

            Hashtable ht = new Hashtable();
            ht.Add("@cNo", param);
            ht.Add("@pNo", pNo);

            DataBase db = new DataBase();
            ArrayList result = db.GetList(spName, ht);
            db.Close();
            return result;
        }

        [Route("insert/Note")]
        [HttpPost]
        public int post([FromForm] string cNo, [FromForm] string bTitle, [FromForm] string bContents, [FromForm] string MemberNo)
        {

            Hashtable ht = new Hashtable();

            ht.Add("@cNo", cNo);
            ht.Add("@bTitle", bTitle);
            ht.Add("@bContents", bContents);
            ht.Add("@MemberNo", MemberNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Board_Insert_proc", ht);
            db.Close();
            return result;
        }

        [Route("delete/Reply")]
        [HttpPost]
        public int Replydelete([FromForm] string rNo, [FromForm] string uNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@rNo", rNo);
            ht.Add("@uNo", uNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Reply_Delete", ht);
            db.Close();
            return result;
        }

        [Route("delete/Note")]
        [HttpPost]
        public ActionResult<string> post([FromForm] string spName, [FromForm] string bNo)
        {
            Console.WriteLine("spName : {0}, bNo : {1}", spName, bNo);
            Hashtable ht = new Hashtable();

            ht.Add("@bNo", bNo);
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

        [Route("insert/Reply")]
        [HttpPost]
        public int post([FromForm] string bNo, [FromForm] string uNo, [FromForm] string rContent)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@bNo", bNo);
            ht.Add("@uNo", uNo);
            ht.Add("@rContent", rContent);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Reply_Insert", ht);
            db.Close();
            return result;
        }
    }
}
