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
        private Panel pnl_list;
        private Panel pnl_top;
        private Panel pnl_bottom;
        private Hashtable ht;
        private Form parentForm;
        private Commons comm;
        private Chart chart;
        private ListView Dash_lv;
        private Panel pnl_group;
        private Label lb_title;

        public DashBoardView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            UrlInfo_porc();
            parentForm.BackColor = Color.DimGray;
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(960, 820));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);


            ht = new Hashtable();
            ht.Add("size", new Size(900, 350));
            ht.Add("point", new Point(40, 30));
            ht.Add("name", "chart");
            chart = comm.getChart(ht, pnl_group);
            chart.Series[0].Color = Color.Black;
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Points.AddXY("", "");
            chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart.Series[0].MarkerSize = 4;
            //chart.ChartAreas[0].AxisX.Interval = 1;

            ht = new Hashtable();
            ht.Add("size", new Size(940, 70));
            ht.Add("point", new Point(10, 410));
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
            ht.Add("point", new Point(10, 480));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "bottom");
            pnl_bottom = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_bottom);
            Dash_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url 정보", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Path", 300, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("조회수", 100, HorizontalAlignment.Center);
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            
        }

        private void UrlInfo_porc()
        {
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Url_Info_Proc");
            ht.Add("param", "");
            Dash_lv.Items.Clear();
            ArrayList list = api.Select("http://localhost:5000/select", ht);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    JArray ja = (JArray)list[i];
            //    string[] arr = new string[ja.Count];
            //    for (int j = 0; j < ja.Count; j++)
            //    {
            //        arr[j] = ja[j].ToString();
            //        arr[4] = ja[4].ToString();

            //    }
            //    //MessageBox.Show(arr[4]);
            //    chart.Series[0].Points.Add(Convert.ToInt32(arr[4]));
            //    Dash_lv.Items.Add(new ListViewItem(arr));
            //}

            ArrayList result = new ArrayList();
            foreach (JObject row in list)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                   
                    ht.Add(col.Name, col.Value);
                }
                result.Add(ht);
            }
            foreach (Hashtable ht in result)
            {
                chart.Series[0].Points.Add(Convert.ToInt32(ht["uView"].ToString()));
                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["UrlNo"].ToString(), ht["UrlName"].ToString(), ht["UrlPath"].ToString(), ht["uView"].ToString() }));
            }
        }
    }
}
