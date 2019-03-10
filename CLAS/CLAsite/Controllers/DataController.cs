using System;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace CLAsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ArrayList Get()
        {
            ArrayList list = new ArrayList();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = string.Format(@"server=(localdb)\ProjectsV13;uid=root;password=1234;database=CLAS;");

            try
            {
                conn.Open();
                string sql = "select * from Users";
                SqlCommand comm = new SqlCommand(sql,conn);
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    Hashtable ht = new Hashtable();
                    for(int i = 0; i< sdr.FieldCount; i++)
                    {
                        ht.Add(sdr.GetName(i), sdr.GetValue(i));
                    }
                    list.Add(ht);
                }
            }
            catch 
            {
                Console.WriteLine("DB Connection erro");
            }
            return list;
        }
    }
}