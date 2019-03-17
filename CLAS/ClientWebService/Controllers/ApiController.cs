using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClientWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        [Route("select")]
        [HttpPost]
        public ActionResult<ArrayList> select([FromForm] string spName, [FromForm]string param)
        {
            
            Console.WriteLine("spName : {0}, param : {1}", spName, param);
            Hashtable ht = new Hashtable();
            if (!String.IsNullOrEmpty(param))
            {
                string[] str = param.Split(":");
                ht.Add(str[0], str[1]);
                Console.WriteLine(str[0] + str[1]);
            }


            DataBase db = new DataBase();
            ArrayList result = db.GetList(spName, ht);
            db.Close();
            return result;
        }


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

        [Route("select/Category")]
        [HttpGet]
        public ActionResult<ArrayList> select()
        {

            DataBase db = new DataBase();
            SqlDataReader sdr = db.Reader("Content_type");
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.WriteLine(sdr.GetValue(i).ToString());
                    arr[i] = sdr.GetValue(i).ToString();
                }
                list.Add(arr);
            }
            db.ReaderClose(sdr);
            db.Close();
            Console.WriteLine("asd : {0}", list.Count.ToString());
            return list;
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



        [Route("update/Cnt")]
        [HttpPost]
        public int post([FromForm] string bNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@bNo", bNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Board_cnt", ht);
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
    }
}
