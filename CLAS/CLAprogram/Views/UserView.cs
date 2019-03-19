using CLAprogram.Forms;
using CLAprogram.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class UserView
    {
        private Panel pnl_bottom;
        private Panel pnl_top;
        private Panel pnl_center;
        private TextBox txt_serach;
        private Label lb_title;
        private Hashtable ht;
        private Form parentForm;
        private Commons comm;
        private Control pnl_group;
        private Button btn_Board;
        public ListView Dash_lv;
        private string mNo;

        public UserView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            parentForm.BackColor = Color.DimGray;
            UserInfo_list();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(960, 70));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht, parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(960, 750));
            ht.Add("point", new Point(10, 80));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "center");
            pnl_center = comm.getPanel(ht, parentForm);


            ht = new Hashtable();
            ht.Add("size", new Size(940, 70));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "top");
            pnl_top = comm.getPanel(ht, pnl_center);


            ht = new Hashtable();
            ht.Add("size", new Size(940, 660));
            ht.Add("point", new Point(10, 80));
            ht.Add("color", Color.DimGray);
            ht.Add("name", "bottom");
            pnl_bottom = comm.getPanel(ht, pnl_center);

            ht = new Hashtable();
            ht.Add("point", new Point(28, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "사용자 정보 조회");
            lb_title = comm.getLabel(ht, pnl_top);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(800, 600));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_bottom);
            Dash_lv.Columns.Add("No", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("아이디", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("패스워드", 150, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("이름", 200, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("멤버유형", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("생성날짜", 235, HorizontalAlignment.Center);
            Dash_lv.Click += Dash_lv_Click;

            ht = new Hashtable();
            ht.Add("width", 400);
            ht.Add("point", new Point(20, 20));
            ht.Add("name", "검색텍스트");
            ht.Add("font", new Font("Microsoft Sans Serif", 20));
            txt_serach = comm.getTextBox(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 40));
            ht.Add("point", new Point(425, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "search");
            ht.Add("text", "검색");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 40));
            ht.Add("point", new Point(740, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "restart");
            ht.Add("text", "새로고침");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 40));
            ht.Add("point", new Point(845, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "delete");
            ht.Add("text", "삭제");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

        }

        /// <summary>
        /// 리스트뷰 클릭 이벤트
        /// </summary>
        private void Dash_lv_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                mNo = item.SubItems[0].Text;
                //MessageBox.Show(mNo);
            }
        }

        /// <summary>
        /// 리스트뷰 더블 클릭 이벤트
        /// </summary>
        private void lv_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                mNo = item.SubItems[0].Text;
                //MessageBox.Show(mNo);

                LogForm log;
                log = new LogForm(mNo);
                log.ShowDialog();
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            WebAPI api = new WebAPI();
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "search":
                    if(txt_serach.Text == "")
                    {
                        MessageBox.Show("아이디를 입력하세요");
                    }
                    else
                    {
                        api = new WebAPI();
                        ht = new Hashtable();
                        ht.Add("spName", "user_search");
                        ht.Add("param", "@mId:" + txt_serach.Text);
                        ArrayList list = api.Select(Program.serverUrl + "select", ht);
                        Dash_lv.Items.Clear();
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
                            Dash_lv.Items.Add(new ListViewItem(new string[] { ht["MemberNo"].ToString(), ht["MemberId"].ToString(), ht["MemberPassword"].ToString(), ht["MemberName"].ToString(), ht["MemberState"].ToString(), ht["regDate"].ToString() }));
                        }
                    }

                    break;
                case "restart":
                    UserInfo_list();
                    break;
                case "delete":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("mNo", mNo);
                    if (!api.Post(Program.serverUrl + "api/deleteMember", ht))
                    {
                        MessageBox.Show("삭제 실패");
                        break;
                    }
                    MessageBox.Show("삭제되었습니다.");
                    UserInfo_list();
                    break;
                default:
                    break;
            }
        }



        private void UserInfo_list()
        {
            Dash_lv.Items.Clear();
            WebAPI api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Member_Info");
            ht.Add("param", "");
           
            ArrayList list = api.Select(Program.serverUrl + "select", ht);

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
                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["MemberNo"].ToString(), ht["MemberId"].ToString(), ht["MemberPassword"].ToString(), ht["MemberName"].ToString(), ht["MemberState"].ToString(), ht["regDate"].ToString() }));
            }
        }
    }
}
