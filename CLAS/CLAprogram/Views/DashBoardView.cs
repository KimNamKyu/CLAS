using CLAprogram.Models;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CLAprogram.Views
{
    class DashBoardView
    {
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

        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(900, 350));
            ht.Add("point", new Point(40, 30));
            ht.Add("name", "chart");
            chart = comm.getChart(ht, parentForm);
            chart.Series[0].Color = Color.Black;
            chart.Series[0].ChartType = SeriesChartType.Spline;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Points.AddXY("", "");
            chart.ChartAreas[0].AxisX.Interval = 1;

            ht = new Hashtable();
            ht.Add("size", new Size(900, 300));
            ht.Add("point", new Point(40, 420));
            ht.Add("color", Color.Pink);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);


            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_group);
            Dash_lv.Columns.Add("", 25, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("No", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Path", 300, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Name", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Count", 100, HorizontalAlignment.Center);
            pnl_group.Controls.Add(Dash_lv);
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
