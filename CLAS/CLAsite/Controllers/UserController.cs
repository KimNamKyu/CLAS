using System;
using System.Collections;
using System.Data.SqlClient;
using CLAsite.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Moules;

namespace CLAsite.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        DataBase db;
        [Route("select")]
        [HttpPost]
        public ActionResult<ArrayList> select([FromForm] string spName, [FromForm] string param)
        {
            Console.WriteLine("spName : {0}, param : {1}", spName, param);
            Hashtable ht = new Hashtable();
            if (!String.IsNullOrEmpty(param))
            {
                string[] str = param.Split(":");
                ht.Add(str[0], str[1]);

                Console.WriteLine("11111");
            }

            db = new DataBase();
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

        [Route("succ")]
        [HttpPost]
        public ActionResult<ArrayList> post()
        {
            DataBase db = new DataBase();
            SqlDataReader sdr = db.Reader("sp_select");
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                list.Add(arr);
            }
            db.ReaderClose(sdr);

            return list;
        }

    }
}