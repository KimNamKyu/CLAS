using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class LoguserView
    {
        private Form parentForm;
        private string mNo;
        private Commons comm;
        private WebAPI api;
        private Hashtable ht;
        private Panel pnl_group;
        private Panel pnl_item;
        private Panel pnl_item_title;
        private ListView Dash_lv;
        private Label lb_title;

        public LoguserView(Form parentForm, string mNo)
        {
            this.parentForm = parentForm;
            this.mNo = mNo;
            comm = new Commons();
            getView();
            parentForm.BackColor = Color.DimGray;
            UrlInfo_porc();
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(760, 760));
            ht.Add("point", new Point(18, 17));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);
            pnl_group.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(738, 80));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_item = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("point", new Point(20, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "유저 Log 상세 조회");
            lb_title = comm.getLabel(ht, pnl_item);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(738, 650));
            ht.Add("point", new Point(10, 90));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_item_title = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_item_title);
            Dash_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("유저이름", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("경로명", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("접속날짜", 240, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("로그아웃날짜", 240, HorizontalAlignment.Center);
           
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {

        }

        private void UrlInfo_porc()
        {
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "log_user_info");
            ht.Add("param", "@mNo:"+mNo);
            Dash_lv.Items.Clear();
            ArrayList list = api.Select(Program.serverUrl + "select", ht);


            ArrayList result = new ArrayList();
            foreach (JObject row in list)
            {
                Hashtable ht = new Hashtable();

                foreach (JProperty col in row.Properties())
                {
                    //MessageBox.Show(col.Name, col.Value.ToString());
                    ht.Add(col.Name, col.Value);
                }
                result.Add(ht);

                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["mNo"].ToString(), ht["MemberName"].ToString(), ht["urlName"].ToString() , ht["enter"].ToString(), ht["leave"].ToString() }));
            }
        }
    }
}
