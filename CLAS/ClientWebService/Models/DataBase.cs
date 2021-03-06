﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebService.Models
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

        public int NonQuerys(string sql, Hashtable ht)
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

                    int cnt = comm.ExecuteNonQuery();
                    return cnt;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
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

        public ArrayList GetList(string sql, Hashtable ht)
        {
            if (status)
            {
                ArrayList result = new ArrayList();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = sql;
                    comm.CommandType = CommandType.StoredProcedure;
                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Hashtable col = new Hashtable();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            col.Add(reader.GetName(i), reader.GetValue(i));
                        }
                        result.Add(col);
                    }
                    reader.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }


    }
}
