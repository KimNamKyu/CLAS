using CLAprogram.Forms;
using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class NoticeView
    {

        private Form parentForm;
        private Commons comm;
        private Panel pnl_group;
        private WebAPI api;
        private Panel pnl_top;
        private Panel pnl_center;
        private Panel pnl_bottom;
        private Hashtable ht;
        private Button btn_Board;
        private ComboBox comboCategory;
        private string[] cNo;
        public string[] arr;
        public ListView Dash_lv;
        public string nTitle;
        public string Subject;
        public string Content;
        //private Detail_Info detail_Info;
        private string bNo;
        public string UserNo;
        private Detail_Info detail_Info;
        private Label lb_title;
        private string BNo;

        public NoticeView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            parentForm.BackColor = Color.DimGray;
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
            //ht.Add("size", new Size(500, 300));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "Dash_lv");
            ht.Add("click", (MouseEventHandler)lv_Click);
            Dash_lv = comm.GetListView(ht, pnl_bottom);
            Dash_lv.Click += Dash_lv_Click;
            Dash_lv.Columns.Add("bNo", 0, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("No", 50, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("제목", 190, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("내용", 350, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("작성자", 100, HorizontalAlignment.Center);
            Dash_lv.Columns.Add("작성일", 240, HorizontalAlignment.Center);
                                    
            ht = new Hashtable();
            ht.Add("size", new Size(100, 40));
            ht.Add("point", new Point(740, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "delete");
            ht.Add("text", "삭제");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 40));
            ht.Add("point", new Point(845, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "write");
            ht.Add("text", "글쓰기");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("point", new Point(28, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "게시물 정보 관리");
            lb_title = comm.getLabel(ht, pnl_top);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("width", 300);
            ht.Add("point", new Point(15, 20));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("font", new Font("맑은고딕", 15, FontStyle.Bold));
            ht.Add("name", "comboCategory");
            comboCategory = comm.getComboBox(ht, pnl_group);
            api = new WebAPI();
            ArrayList list = api.SelectCategory(Program.serverUrl + "select/Category");
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
            comboCategory.Font = new Font("맑은 고딕", 15, FontStyle.Bold);
        }

        private void Dash_lv_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                
                BNo = item.SubItems[0].Text;
                //MessageBox.Show(BNo);
            }
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
                    break;
                case 1:
                    nTitle = arr[1];
                    NoticeInfo_porc(cNo[1]);
                    //btn_Board.Visible = false;
                    
                    break;
                case 2:
                    nTitle = arr[2];
                    NoticeInfo_porc(cNo[2]);
                    //btn_Board.Visible = false;
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
                Subject = item.SubItems[2].Text;
                //MessageBox.Show(Subject);
                Content = item.SubItems[3].Text;
                //MessageBox.Show(Content);
                //MessageBox.Show(item.SubItems[0].Text);
                bNo = item.SubItems[0].Text;
                detail_Info = new Detail_Info(bNo,nTitle, Subject, Content);
                detail_Info.ShowDialog();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "delete":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("spName", "Board_delete_proc");
                    ht.Add("bNo", bNo);
                    if (!api.Post(Program.serverUrl + "delete/Note", ht))
                    {
                        MessageBox.Show("삭제 실패");
                        break;
                    }
                    MessageBox.Show("삭제되었습니다.");
                    NoticeInfo_porc(cNo[0]);
                    break;
                case "write":
                    detail_Info = new Detail_Info();
                    detail_Info.ShowDialog();
                    Dash_lv.Items.Clear();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Contents 목록 조회
        /// </summary>
        /// 1 : 공지사항 /  2 : 커뮤니티 / 3 : QnA 
        public void NoticeInfo_porc(string cNo)
        {
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "Board_Proc");
            ht.Add("param", "@cNo:" + cNo);
            Dash_lv.Items.Clear();
            ArrayList list = api.Select(Program.serverUrl + "select", ht);

            
            ArrayList result = new ArrayList();
            foreach (JObject row in list)
            {
                UserNo = row["MemberNo"].ToString();
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                result.Add(ht);
            }
            foreach (Hashtable ht in result)
            {
                Dash_lv.Items.Add(new ListViewItem(new string[] { ht["bNo"].ToString(), ht["sort"].ToString(), ht["bTitle"].ToString(), ht["bContents"].ToString(), ht["MemberName"].ToString(), ht["regDate"].ToString() }));
            }
           
        }
    }
}
