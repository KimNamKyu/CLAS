using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Server.Moules
{
    public class DataBase
    {
        private SqlConnection conn;
        private bool status;

        public DataBase()
        {
            status = Connection();
        }
        private bool Connection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = conn.ConnectionString = string.Format(@"server=(localdb)\ProjectsV13;uid=root;password=1234;database=CLAS;");
                conn.Open();
                System.Console.WriteLine("DB Connection Success");
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



        public SqlDataReader Reader(string sql, Hashtable ht)
        {
            if (status)  //연결된 상태일 때만
            {
                System.Console.WriteLine("상태 DB On");
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        System.Console.WriteLine(data.Key.ToString(), data.Value);
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

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

        public SqlDataReader Reader(string sql)
        {
            if (status)  //연결된 상태일 때만
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

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
    }
}