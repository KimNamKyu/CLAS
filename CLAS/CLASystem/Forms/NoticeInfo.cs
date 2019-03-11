﻿using Commons;
using Newtonsoft.Json.Linq;
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
        private WebAPI api;
        private Hashtable ht;
        private Button btn_Board;
        private ComboBox comboCategory;
        private string[] cNo;
        public string[] arr;
        public ListView Dash_lv;
        public string nTitle;
        public string Subject;
        public string Content;
        private Detail_Info detail_Info;
        public string UserNo;

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
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht);

            Dash_lv.Columns.Add("No", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("제목", 150, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("내용", 300, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("작성자", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("작성일", 240, HorizontalAlignment.Center);
            pnl_group.Controls.Add(Dash_lv);

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(760, 625));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "delete");
            ht.Add("text", "삭제");
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
            api = new WebAPI();
            ArrayList list = api.SelectCategory("http://localhost:5000/select/Category");
            arr = new string[list.Count];
            cNo = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                JArray j = (JArray)list[i];
                cNo[i] = j.Value<string>(0).ToString();
                arr[i] = j.Value<string>(1).ToString();
            }

            comboCategory.SelectedIndexChanged += ComboCategory_SelectedIndexChanged;
            comboCategory.Items.AddRange(arr);
            comboCategory.Font = new Font("맑은 고딕", 13, FontStyle.Bold);
            Controls.Add(comboCategory);

        }

        /// <summary>
        /// 콤보박스 클릭 이벤트 
        /// 공지사항 / 커뮤니티 / QnA
        /// </summary>
        private void ComboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    nTitle = arr[0];
                    NoticeInfo_porc(cNo[0]);

                    ht = new Hashtable();
                    ht.Add("size", new Size(100, 60));
                    ht.Add("point", new Point(850, 30));
                    ht.Add("color", Color.Gainsboro);
                    ht.Add("name", "write");
                    ht.Add("text", "글쓰기");
                    ht.Add("click", (EventHandler)btn_Click);
                    btn_Board = comm.getButton(ht);
                    Controls.Add(btn_Board);

                    break;
                case 1:
                    nTitle = arr[1];
                    NoticeInfo_porc(cNo[1]);
                    btn_Board.Visible = false;
                    break;
                case 2:
                    nTitle = arr[2];
                    NoticeInfo_porc(cNo[2]);
                    btn_Board.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "delete":
                    MessageBox.Show("삭제");
                    break;
                case "write":
                    detail_Info = new Detail_Info(nTitle, cNo[0]);
                    detail_Info.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void lv_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                Subject = item.SubItems[1].Text;
                Content = item.SubItems[2].Text;
                UserNo = item.SubItems[5].Text;
                //MessageBox.Show(UserNo);
                detail_Info = new Detail_Info(nTitle, Subject, Content,UserNo);
                detail_Info.ShowDialog();
            }
        }


        /// <summary>
        /// Contents 목록 조회
        /// </summary>
        /// 1 : 공지사항 /  2 : 커뮤니티 / 3 : QnA 
        private void NoticeInfo_porc(string cNo)
        {
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Board_Proc");
            ht.Add("param", "@cNo:"+ cNo);
            Dash_lv.Items.Clear();
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
