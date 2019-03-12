using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class UserView
    {
        private Hashtable ht;
        private Form parentForm;
        private Commons comm;
        private Control pnl_group;
        private Button btn_Board;
        private string _mNo;
        public ListView Dash_lv;

        public UserView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            UserInfo_list();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(900, 500));
            ht.Add("point", new Point(40, 100));
            ht.Add("color", Color.Blue);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht,parentForm);

            ht = new Hashtable();
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht,parentForm);

            Dash_lv.Columns.Add("No", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("아이디", 150, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("패스워드", 150, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("이름", 150, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("멤버유형", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("생성날짜", 240, HorizontalAlignment.Center);
            pnl_group.Controls.Add(Dash_lv);

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(760, 625));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "user");
            ht.Add("text", "사용자");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht,parentForm);
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                _mNo = item.SubItems[0].Text;
                MessageBox.Show(_mNo);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void UserInfo_list()
        {
            WebAPI api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Member_Info");
            ht.Add("param", "");

            ArrayList list = api.Select("http://localhost:5000/select", ht);

            for (int i = 0; i < list.Count; i++)
            {
                JArray ja = (JArray)list[i];
                string[] arr = new string[ja.Count];
                for (int j = 0; j < ja.Count; j++)
                {
                    arr[j] = ja[j].ToString();
                }
                Dash_lv.Items.Add(new ListViewItem(arr));
            }
        }
    }
}
