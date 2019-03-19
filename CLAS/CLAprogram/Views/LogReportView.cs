using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class LogReportView
    {
        private Form parentForm;
        private Commons comm;
        private Panel pnl_item;
        private Panel pnl_item_title;
        private WebAPI api;
        private Hashtable ht;
        private Panel pnl_group;
        private Label lb_title;
        private ListView Dash_lv;
        private Timer timer = new Timer();
        private Button btn_stop;

        public LogReportView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            getView();
            parentForm.BackColor = Color.DimGray;
            timer.Tick += new EventHandler(UrlInfo_porc);
            timer.Start();
            parentForm.FormClosed += ParentForm_FormClosed;
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
            ht.Add("text", "실시간 로그 기록");
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
            ht.Add("click", null);
            Dash_lv = comm.GetListView(ht, pnl_item_title);
            Dash_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("유저이름", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("경로명", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("접속날짜", 240, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("로그아웃날짜", 240, HorizontalAlignment.Center);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(630, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "중지");
            ht.Add("text", "실시간 중지");
            ht.Add("click", (EventHandler)btn_Click);
            btn_stop = comm.getButton(ht, pnl_item);
            btn_stop.Font = new Font("Microsoft Sans Serif", 15);
        }
        bool status = true;
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (status)
            {
                case true:
                    timer.Stop();
                    status = false;
                    MessageBox.Show("실시간 조회가 중지되었습니다.");
                    btn_stop.Text = "실시간 조회";
                    break;
                case false:
                    timer.Start();
                    status = true;
                    MessageBox.Show("실시간 조회되었습니다.");
                    btn_stop.Text = "실시간 중지";
                    break;
                default:
                    break;
            }
        }

        private void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }


        private void UrlInfo_porc(object sender, EventArgs eventArgs)
        {
            timer.Interval = 2000;
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "real_Info");
            ht.Add("param", "");
            Dash_lv.Items.Clear();
            ArrayList list = api.Select(Program.serverUrl + "select", ht);

            foreach (JObject row in list)
            {
                Hashtable ht = new Hashtable();

                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["mNo"].ToString(), ht["urlName"].ToString(), ht["MemberName"].ToString(), ht["enter"].ToString(), ht["leave"].ToString() }));
            }
        }
    }
}
