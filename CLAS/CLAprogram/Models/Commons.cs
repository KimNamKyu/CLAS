using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CLAprogram.Models
{
    public class Commons
    {
        //public Form getMdiForm(Form parentForm, Form tagetForm, Control parentDomain)
        //{
        //    parentForm.IsMdiContainer = true;
        //    tagetForm.MdiParent = parentForm;
        //    tagetForm.WindowState = FormWindowState.Maximized;
        //    tagetForm.FormBorderStyle = FormBorderStyle.None;
        //    tagetForm.Dock = DockStyle.Fill;
        //    parentDomain.Controls.Add(tagetForm);
        //    return tagetForm;
        //}

        public Panel getPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;
        }

        public Label getLabel(Hashtable hashtable, Control parentDomain)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = (Point)hashtable["point"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            label.Font = (Font)hashtable["font"];
            parentDomain.Controls.Add(label);
            return label;
        }


        public Button getButton(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = (Size)hashtable["size"];
            button.Location = (Point)hashtable["point"];
            button.BackColor = (Color)hashtable["color"];
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            parentDomain.Controls.Add(button);
            return button;
        }


        public TextBox getTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            textBox.Name = hashtable["name"].ToString();
            textBox.Font = (Font)hashtable["font"];
            //textBox.BackColor = (Color)hashtable["color"];
            //textBox.Enabled = (bool)hashtable["enabled"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }


        public ComboBox getComboBox(Hashtable hashtable, Control parentDomain)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.Font = (Font)hashtable["font"];
            comboBox.Name = hashtable["name"].ToString();
            //comboBox.DisplayMember = "value";
            //comboBox.ValueMember = "Key";
            parentDomain.Controls.Add(comboBox);
            return comboBox;
        }

        public ListView GetListView(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            //listView.Location = (Point)hashtable["point"];
            //listView.Size = (Size)hashtable["size"];
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseDoubleClick += (MouseEventHandler)hashtable["click"];
            listView.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            parentDomain.Controls.Add(listView);
            return listView;
        }

        

        public CheckBox getCheckBox(Hashtable hashtable, Control parentDomain)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Location = (Point)hashtable["point"];
            checkBox.Name = hashtable["name"].ToString();
            checkBox.Text = hashtable["text"].ToString();
            checkBox.Font = new Font("고딕", 15, FontStyle.Bold);
            parentDomain.Controls.Add(checkBox);
            //checkBox.TabIndex = 
            return checkBox;
        }

        public PictureBox getPictureBox(Hashtable hashtable, Control parentDomain)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackgroundImage = (Image)hashtable["image"];
            pictureBox.Location = (Point)hashtable["point"];
            pictureBox.Size = (Size)hashtable["size"];
            //pictureBox.BackColor = (Color)hashtable["color"];
            parentDomain.Controls.Add(pictureBox);
            return pictureBox;
        }

        public DateTimePicker GetDateTimePicker(Hashtable hashtable, Control parentDomain)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Font = new Font("맑은 고딕", 11);
            dateTimePicker.Location = (Point)hashtable["point"];
            dateTimePicker.Name = hashtable["name"].ToString();
            dateTimePicker.Size = (Size)hashtable["size"];
            dateTimePicker.TabIndex = 0;
            parentDomain.Controls.Add(dateTimePicker);
            return dateTimePicker;
        }

        public Chart getChart(Hashtable hashtable, Control parentDomain)
        {
            ChartArea chartArea = new ChartArea();
            Chart chart = new Chart();
            Series series = new Series();
            
            //=================chart area===========================
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.Name = "ChartArea";
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
            //chartArea.BackColor = Color.AliceBlue;
            //===================chart==============================
            chart.ChartAreas.Add(chartArea);
            chart.Location = (Point)hashtable["point"];
            chart.Name = hashtable["name"].ToString();

            series.ChartArea = "ChartArea";
            series.Name = "Series";
            //series.BorderColor = Color.Black;
            //series.BorderWidth = 1;
            //series.LabelAngle = 90;
            chart.Series.Add(series);


            chart.Size = (Size)hashtable["size"];
            parentDomain.Controls.Add(chart);
            return chart;
        }

        public Chart getchart(Hashtable hashtable, Control parentDomain)
        {
            Chart chart = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            chartArea1.Name = hashtable["areaname"].ToString();
            legend1.Name = hashtable["legname"].ToString();
            series1.ChartArea = hashtable["areaname"].ToString();
            series1.Legend = hashtable["legname"].ToString();
            series1.Name = hashtable["seriname"].ToString();
            // 차트 기본
            chart.Name = hashtable["chartname"].ToString();
            chart.Dock = DockStyle.Fill;
            chart.Text = hashtable["text"].ToString();
            chart.ChartAreas.Add(chartArea1);
            chart.Legends.Add(legend1);
            chart.Series.Add(series1);
            chart.Series[series1.Name].IsValueShownAsLabel = true;

            parentDomain.Controls.Add(chart);
            return chart;
        }

    }
}
