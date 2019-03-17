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

       
    }
}
