using System;
using System.Collections;
using System.Data.SqlClient;
using CLAsite.Moules;
using Microsoft.AspNetCore.Mvc;

namespace CLAsite.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
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
            SqlDataReader sdr = db.Reader(spName, ht);
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
        public ActionResult<string> sp_insert([FromForm] string spName, [FromForm] string cNo, [FromForm] string bTitle, [FromForm] string bContents, [FromForm] string MemberNo)
        {
            Console.WriteLine("spName : {0}, cNo : {1}, bTitle : {2}, bContents : {3}, MemberNo : {4}", spName, cNo, bTitle, bContents, MemberNo);
            Hashtable ht = new Hashtable();

            ht.Add("@cNo", cNo);
            ht.Add("@bTitle", bTitle);
            ht.Add("@bContents", bContents);
            ht.Add("@MemberNo", MemberNo);
            DataBase db = new DataBase();
            if (db.NonQuery(spName, ht))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}