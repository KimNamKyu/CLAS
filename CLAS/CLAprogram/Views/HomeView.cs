using CLAprogram.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CLAprogram.Views
{
    class HomeView
    {
        private Form parentForm;
        private Commons comm;
        private Hashtable ht;
        private Chart Chart;

        public HomeView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(35, 550));
            ht.Add("name", "chart");
            Chart = comm.getChart(ht, parentForm);
            Chart.Series[0].Color = Color.Black;
            Chart.Series[0].ChartType = SeriesChartType.Doughnut;
            Chart.Series[0].IsValueShownAsLabel = true;
            Chart.Series[0].Points.AddXY("", "");
            Chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            Chart.Series[0].MarkerSize = 4;
            Chart.Series[0].Points.Add(8);

            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(345, 550));
            ht.Add("name", "chart");
            Chart = comm.getChart(ht, parentForm);
            Chart.Series[0].Color = Color.Black;
            Chart.Series[0].ChartType = SeriesChartType.Doughnut;
            Chart.Series[0].IsValueShownAsLabel = true;
            Chart.Series[0].Points.AddXY("", "");
            Chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            Chart.Series[0].MarkerSize = 4;
            Chart.Series[0].Points.Add(8);

            ht = new Hashtable();
            ht.Add("size", new Size(300, 250));
            ht.Add("point", new Point(655, 550));
            ht.Add("name", "chart");
            Chart = comm.getChart(ht, parentForm);
            Chart.Series[0].Color = Color.Black;
            Chart.Series[0].ChartType = SeriesChartType.Doughnut;
            Chart.Series[0].IsValueShownAsLabel = true;
            Chart.Series[0].Points.AddXY("", "");
            Chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            Chart.Series[0].MarkerSize = 4;
            Chart.Series[0].Points.Add(8);
        }
    }
}
