using Commons;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLASystem.Forms
{
    public partial class NoticeInfo : Form
    {
        private Common comm;
        private Panel pnl_group;
        private Hashtable ht;
        private Button btn_Board;
        private ComboBox comboCategory;

        public ListView Dash_lv;

        public NoticeInfo()
        {
            InitializeComponent();
            Load += NoticeInfo_Load;
        }

        private void NoticeInfo_Load(object sender, EventArgs e)
        {
            GetView();   
        }

        private void GetView()
        {
            comm = new Common();
            ht = new Hashtable();
            ht.Add("size", new Size(900, 500));
            ht.Add("point", new Point(40, 100));
            ht.Add("color", Color.Green);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht);
            Controls.Add(pnl_group);

            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht);
            Dash_lv.Columns.Add("", 25, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("No", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Path", 300, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Url Name", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("Count", 100, HorizontalAlignment.Center);
            pnl_group.Controls.Add(Dash_lv);

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(760, 625));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "user");
            ht.Add("text", "사용자");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht);
            Controls.Add(btn_Board);

            ht = new Hashtable();
            ht.Add("width", 300);
            ht.Add("point", new Point(40, 30));
            ht.Add("color", Color.Gainsboro);
            ht.Add("font", new Font("맑은고딕", 14, FontStyle.Bold));
            ht.Add("name", "comboCategory");
            comboCategory = comm.getComboBox(ht);
            Controls.Add(comboCategory);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            
        }
    }
}
