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
        private Hashtable ht;
        private Form parentForm;
        private Commons comm;
        private Chart chart;
        private ListView Dash_lv;
        private Panel pnl_group;

        public DashBoardView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            UrlInfo_porc();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(900, 350));
            ht.Add("point", new Point(40, 30));
            ht.Add("name", "chart");
            chart = comm.getChart(ht, parentForm);
            chart.Series[0].Color = Color.Black;
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Points.AddXY("", "");
            chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart.Series[0].MarkerSize = 4;
            //chart.ChartAreas[0].AxisX.Interval = 1;
           
           

            ht = new Hashtable();
            ht.Add("size", new Size(900, 300));
            ht.Add("point", new Point(40, 420));
            ht.Add("color", Color.Pink);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);


            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_group);
            Dash_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url 정보", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Path", 300, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("생성날짜", 250, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("조회수", 100, HorizontalAlignment.Center);
            pnl_group.Controls.Add(Dash_lv);
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

            for (int i = 0; i < list.Count; i++)
            {
                JArray ja = (JArray)list[i];
                string[] arr = new string[ja.Count];
                for (int j = 0; j < ja.Count; j++)
                {
                    arr[j] = ja[j].ToString();
                    arr[4] = ja[4].ToString();
                    
                }
                //MessageBox.Show(arr[4]);
                chart.Series[0].Points.Add(Convert.ToInt32(arr[4]));
                Dash_lv.Items.Add(new ListViewItem(arr));
            }
        }
    }
}
