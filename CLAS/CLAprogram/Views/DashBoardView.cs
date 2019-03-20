using CLAprogram.Forms;
using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CLAprogram.Views
{
    class DashBoardView
    {
        private WebAPI api;
        private Panel pnl_top;
        private Panel pnl_bottom;
        private Panel pnl_center;
        private Button btn_log;
        private Hashtable ht;
        private Form parentForm;
        private Commons comm;
        private ListView Dash_lv;
        private Panel pnl_group;
        private Label lb_title;
        private Chart chartTotal;
        private Chart chartuser;
        private Chart chartNon;
        private Panel pnl_body1;
        private Panel pnl_body2;
        private Panel pnl_body3;
        private Panel pnl_text1;
        private Panel pnl_text2;
        private Panel pnl_text3;
        private Label lb_Total;
        private Label lb_Nonuser;
        private Label lb_user;
        private int Total = 0;
        private int usercnt = 0;
        private int nonusercnt = 0;
        private Timer timer = new Timer();

        public DashBoardView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            parentForm.BackColor = Color.DimGray;
            
            timer.Tick += new EventHandler(UrlInfo_porc);
            timer.Start();

            parentForm.FormClosed += ParentForm_FormClosed;
            parentForm.Disposed += ParentForm_Disposed;   
        }

        private void ParentForm_Disposed(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(960, 820));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);

            /*===================================*/
            ht = new Hashtable();
            ht.Add("size", new Size(250, 50));
            ht.Add("point", new Point(10 , 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_body1 = comm.getPanel(ht, pnl_group);
            pnl_body1.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(250, 50));
            ht.Add("point", new Point(270, 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_body2 = comm.getPanel(ht, pnl_group);
            pnl_body2.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(250, 50));
            ht.Add("point", new Point(530, 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_body3 = comm.getPanel(ht, pnl_group);
            pnl_body3.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("point", new Point(80, 5));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "Total");
            lb_title = comm.getLabel(ht, pnl_body1);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("point", new Point(5, 5));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "비 유저 접속 컨텐츠 이용수");
            lb_title = comm.getLabel(ht, pnl_body2);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("point", new Point(10, 5));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "유저 컨텐츠 이용수");
            lb_title = comm.getLabel(ht, pnl_body3);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(160, 130));
            ht.Add("point", new Point(790, 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "search");
            ht.Add("text", "실시간 로그기록");
            ht.Add("click", (EventHandler)btn_Click);
            btn_log = comm.getButton(ht, pnl_group);
            btn_log.ForeColor = Color.White;
            btn_log.Font = new Font("Microsoft Sans Serif", 18);

            

            //===================================================


            ht = new Hashtable();
            ht.Add("size", new Size(250, 80));
            ht.Add("point", new Point(10 , 60));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_text1 = comm.getPanel(ht, pnl_group);
            pnl_text1.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(250, 80));
            ht.Add("point", new Point(270, 60));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_text2 = comm.getPanel(ht, pnl_group);
            pnl_text2.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(250, 80));
            ht.Add("point", new Point(530, 60));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_text3 = comm.getPanel(ht, pnl_group);
            pnl_text3.BorderStyle = BorderStyle.FixedSingle;


            ht = new Hashtable();
            ht.Add("point", new Point(85, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "총 방문수");
            lb_Total = comm.getLabel(ht, pnl_text1);
            lb_Total.Font = new Font("Microsoft Sans Serif", 25);
            lb_Total.Size = new Size(700, 60);
            lb_Total.ForeColor = Color.Black;
         
            ht = new Hashtable();
            ht.Add("point", new Point(85, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "비 유저 방문수");
            lb_Nonuser = comm.getLabel(ht, pnl_text2);
            lb_Nonuser.Font = new Font("Microsoft Sans Serif", 25);
            lb_Nonuser.Size = new Size(700, 60);
            lb_Nonuser.ForeColor = Color.Black;
            

            ht = new Hashtable();
            ht.Add("point", new Point(85, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "유저 방문수");
            lb_user = comm.getLabel(ht, pnl_text3);
            lb_user.Font = new Font("Microsoft Sans Serif", 25);
            lb_user.Size = new Size(700, 60);
            lb_user.ForeColor = Color.Black;


            //=============================== 차트 View

            ht = new Hashtable();
            ht.Add("size", new Size(940, 270));
            ht.Add("point", new Point(10, 150));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "top");
            pnl_center = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(10, 10));
            ht.Add("name", "chart");
            ht.Add("legname", "Legend1");
            ht.Add("seriname", "Series1");
            chartNon = comm.getChart(ht, pnl_center);
            chartNon.Series[0].ChartType = SeriesChartType.Doughnut;
            chartNon.Series[0].IsValueShownAsLabel = true;
            chartNon.Series[0].MarkerStyle = MarkerStyle.Diamond;
            


            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(320, 10));
            ht.Add("name", "chart");
            ht.Add("legname", "Legend1");
            ht.Add("seriname", "Series1");
            chartuser = comm.getChart(ht, pnl_center);
            chartuser.Series[0].Color = Color.Black;
            chartuser.Series[0].ChartType = SeriesChartType.Doughnut;
            chartuser.Series[0].IsValueShownAsLabel = true;
            chartuser.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chartuser.Series[0].MarkerSize = 4;
            


            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(630, 10));
            ht.Add("name", "chart");
            ht.Add("legname", "Legend1");
            ht.Add("seriname", "Series1");
            chartTotal = comm.getChart(ht, pnl_center);
            chartTotal.Series[0].Color = Color.Black;
            chartTotal.Series[0].ChartType = SeriesChartType.Doughnut;
            chartTotal.Series[0].IsValueShownAsLabel = true;
            chartTotal.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chartTotal.Series[0].MarkerSize = 4;


            chartNon.Titles.Add("비사용자 접속");
            chartuser.Titles.Add("사용자 접속");
            chartTotal.Titles.Add("통합 접속");

            ht = new Hashtable();
            ht.Add("size", new Size(940, 70));
            ht.Add("point", new Point(10, 435));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "top");
            pnl_top = comm.getPanel(ht, pnl_group);

           

            ht = new Hashtable();
            ht.Add("point", new Point(28, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "URL 정보 관리");
            lb_title = comm.getLabel(ht, pnl_top);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(940, 300));
            ht.Add("point", new Point(10, 505));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "bottom");
            pnl_bottom = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", null);
            Dash_lv = comm.GetListView(ht, pnl_bottom);
            Dash_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url 정보", 190, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Path", 220, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("비유저 Page View", 170, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("유저 Page VIew", 160, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Total View", 140, HorizontalAlignment.Center);
        }


        private void btn_Click(object sender, EventArgs e)
        {
            LogReportForm logReport = new LogReportForm();
            logReport.Show();
        }


        private void UrlInfo_porc(object sender,EventArgs eventArgs)
        {
            timer.Interval = 1000;
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Url_Info_Proc");
            ht.Add("param", "");
            Dash_lv.Items.Clear();
            ArrayList list = api.Select(Program.serverUrl+ "select", ht);

            chartNon.Series[0].Points.Clear();
            chartuser.Series[0].Points.Clear();
            chartTotal.Series[0].Points.Clear();
            nonusercnt = 0;
            usercnt = 0;
            Total = 0;
           

            ArrayList result = new ArrayList();
            foreach (JObject row in list)
            {
                ht = new Hashtable();
               
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                result.Add(ht);
                nonusercnt += Convert.ToInt32(ht["NonUser_cnt"].ToString());
                usercnt += Convert.ToInt32(ht["User_cnt"].ToString());
                Total += Convert.ToInt32(ht["Total"].ToString());
                
                chartNon.Series[0].Points.AddXY(ht["UrlName"].ToString(),Convert.ToInt32(ht["NonUser_cnt"].ToString()));
                chartuser.Series[0].Points.AddXY(ht["UrlName"].ToString(), Convert.ToInt32(ht["User_cnt"].ToString()));
                chartTotal.Series[0].Points.AddXY(ht["UrlName"].ToString(), Convert.ToInt32(ht["Total"].ToString()));
                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["urlNo"].ToString(), ht["UrlName"].ToString(), ht["UrlPath"].ToString(), ht["NonUser_cnt"].ToString(), ht["User_cnt"].ToString(), ht["Total"].ToString() }));
            }
            lb_Total.Text = Total.ToString();
            lb_Nonuser.Text = nonusercnt.ToString();
            lb_user.Text = usercnt.ToString();
        }
    }
}
