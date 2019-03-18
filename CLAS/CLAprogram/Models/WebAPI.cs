using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAprogram.Models
{
    class WebAPI
    {
        public ArrayList Select(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] results = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(results);

                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(resultStr);

                return list;
            }
            catch
            {

                return null;
            }
        }

        public ArrayList ListView(string url, ListView listView, ArrayList list)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                listView.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(arr);
                }
                return arrayList;
            }
            catch
            {
                //MessageBox.Show("실패");
                return null;
            }
        }



        public ArrayList SelectCategory(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                return list;
            }
            catch
            {
                return null;
            }
        }


        public bool Post(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    //MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                byte[] result = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                return true;
            }
            catch
            {
                MessageBox.Show("실패");
                return false;
            }
        }



        public string Posts(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection nameValue = new NameValueCollection();

                foreach (DictionaryEntry data in ht)
                {
                    nameValue.Add(data.Key.ToString(), data.Value.ToString());
                }

                byte[] result = wc.UploadValues(url, "POST", nameValue);
                string resultStr = Encoding.UTF8.GetString(result);
                return resultStr;
            }
            catch
            {
                return "";
            }
        }
    }
}
