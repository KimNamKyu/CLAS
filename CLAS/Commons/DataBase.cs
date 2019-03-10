using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class DataBase
    {
        private SqlConnection conn;
        private bool status;

        public DataBase()
        {
            status = GetConnection();
        }

        private bool GetConnection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = conn.ConnectionString = string.Format(@"server=(localdb)\ProjectsV13;uid=root;password=1234;database=CLAS;");
                conn.Open();
                Console.WriteLine("open : success");
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public void Close()
        {
            if (status == true) conn.Close();
        }


        public SqlDataReader GetReader(string sql, Hashtable ht)
        {
            if (status)  //연결된 상태일 때만
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    Console.WriteLine("asd : {0}", sql);
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    //foreach (DictionaryEntry data in ht)
                    //{
                    //    Console.WriteLine(data.Key.ToString(), data.Value);
                    //    comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    //}

                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    

        public bool NonQuery(string sql, Hashtable ht)
        {

            if (status)
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {

                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    comm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ReaderClose(SqlDataReader sdr)
        {
            try
            {
                sdr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
