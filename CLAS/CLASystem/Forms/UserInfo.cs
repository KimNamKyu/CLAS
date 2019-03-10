using Commons;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLASystem.Forms
{
    public partial class UserInfo : Form
    {
        private Hashtable ht;
        private Common comm;
        private Control pnl_group;
        private Button btn_Board;

        public ListView Dash_lv { get; private set; }

        public UserInfo()
        {
            InitializeComponent();
            Load += UserInfo_Load;
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            GetView();
        }

        private void GetView()
        {
            comm = new Common();
            ht = new Hashtable();
            ht.Add("size", new Size(900, 500));
            ht.Add("point", new Point(40, 100));
            ht.Add("color", Color.Blue);
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
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }

        private void UserInfo_list()
        {

        }
    }
}
