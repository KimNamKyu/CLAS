using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASystem.Forms
{
    public partial class Detail_Info : Form
    {
        private Common comm;
        private WebAPI api;
        private Hashtable ht;
        private Panel pnl_group;
        private Panel pnl_item;
        private Label lb_title;
        private Panel pnl_item_title;
        private TextBox txt_content;
        private string cNo, nTitle, Subject, Content, UserNo; // 공지사항 넘버   // 상단분류 / 제목 / 내용
        NoticeInfo NI = new NoticeInfo();
        private int status;
        private TextBox txt_Title;
        private Button btn_Board;

        public Detail_Info(string nTitle, string Subject, string Content)
        {
            status = 1;
            InitializeComponent();
            Load += Detail_Info_Load;
            this.nTitle = nTitle;
            this.Subject = Subject;
            this.Content = Content;
        }

        public Detail_Info(string cNo, string UserNo)
        {
            status = 2;
            InitializeComponent();
            Load += Detail_Info_Load;
            this.cNo = cNo;
            this.UserNo = UserNo;
            //MessageBox.Show(UserNo);
            //MessageBox.Show(cNo);
        }
        private void Detail_Info_Load(object sender, EventArgs e)
        {
            this.Size = new Size(810, 830);
            this.BackColor = Color.Gainsboro;

            getView();
        }

        private void getView()
        {
            comm = new Common();

            ht = new Hashtable();
            ht.Add("size", new Size(760, 760));
            ht.Add("point", new Point(18, 17));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht);
            pnl_group.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(758, 80));
            ht.Add("point", new Point(0, 0));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_item = comm.getPanel(ht);
            pnl_item.BorderStyle = BorderStyle.FixedSingle;
            pnl_group.Controls.Add(pnl_item);

            
            ht = new Hashtable();
            ht.Add("point", new Point(10, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "분류");
            lb_title = comm.getLabel(ht);
            lb_title.Font = new Font("Microsoft Sans Serif", 30);
            lb_title.Size = new Size(300, 50);
            lb_title.Text = nTitle;
            pnl_item.Controls.Add(lb_title);
            

            ht = new Hashtable();
            ht.Add("size", new Size(758, 678));
            ht.Add("point", new Point(0, 80));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_item_title = comm.getPanel(ht);
            pnl_item_title.BorderStyle = BorderStyle.FixedSingle;
            pnl_group.Controls.Add(pnl_item_title);

            if(status == 1)
            {
                ht = new Hashtable();
                ht.Add("point", new Point(28, 15));
                ht.Add("color", Color.WhiteSmoke);
                ht.Add("name", "title");
                ht.Add("text", "제목 받아와서 넣기");
                lb_title = comm.getLabel(ht);
                lb_title.Font = new Font("Microsoft Sans Serif", 25);
                lb_title.Size = new Size(700, 60);
                lb_title.Text = Subject;
                pnl_item_title.Controls.Add(lb_title);

                ht = new Hashtable();
                ht.Add("width", 700);
                ht.Add("font", new Font("Microsoft Sans Serif", 20));
                ht.Add("point", new Point(28, 80));
                ht.Add("name", "내용");
                txt_content = comm.getTextBox(ht);
                txt_content.Multiline = true;
                txt_content.Height = 400;
                txt_content.Enabled = false;
                txt_content.Enter += Txt_Enter;
                txt_content.Leave += Txt_Leave;
                txt_content.BorderStyle = BorderStyle.FixedSingle;
                txt_content.Text = Content;
                pnl_item_title.Controls.Add(txt_content);
            }

            if(status == 2)
            {
                ht = new Hashtable();
                ht.Add("size", new Size(100, 60));
                ht.Add("point", new Point(520, 10));
                ht.Add("color", Color.Gainsboro);
                ht.Add("name", "저장");
                ht.Add("text", "저장");
                ht.Add("click", (EventHandler)btn_Click);
                btn_Board = comm.getButton(ht);
                pnl_item.Controls.Add(btn_Board);

                ht = new Hashtable();
                ht.Add("size", new Size(100, 60));
                ht.Add("point", new Point(630, 10));
                ht.Add("color", Color.Gainsboro);
                ht.Add("name", "취소");
                ht.Add("text", "취소");
                ht.Add("click", (EventHandler)btn_Click);
                btn_Board = comm.getButton(ht);
                pnl_item.Controls.Add(btn_Board);

                ht = new Hashtable();
                ht.Add("width", 700);
                ht.Add("font", new Font("Microsoft Sans Serif", 25));
                ht.Add("point", new Point(28, 15));
                ht.Add("name", "제목");
                txt_Title = comm.getTextBox(ht);
                txt_Title.Multiline = true;
                txt_Title.Height = 50;
                txt_Title.BorderStyle = BorderStyle.FixedSingle;
                txt_Title.ForeColor = Color.Silver;
                txt_Title.Enter += Txt_Title_Enter;
                txt_Title.Leave += Txt_Title_Leave;
               
                pnl_item_title.Controls.Add(txt_Title);

                    ht = new Hashtable();
                    ht.Add("width", 700);
                    ht.Add("font", new Font("Microsoft Sans Serif", 20));
                    ht.Add("point", new Point(28, 80));
                    ht.Add("name", "내용");
                    txt_content = comm.getTextBox(ht);
                    txt_content.Multiline = true;
                    txt_content.Height = 400;
                
                txt_content.Enabled = true;
                txt_content.Enter += Txt_Enter;
                txt_content.Leave += Txt_Leave;
                txt_content.BorderStyle = BorderStyle.FixedSingle;
                Content = txt_content.Text;
                pnl_item_title.Controls.Add(txt_content);
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "저장":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("spName", "Board_Insert_proc");
                    ht.Add("cNo",cNo);
                    ht.Add("bTitle", txt_Title.Text);
                    ht.Add("bContents", txt_content.Text);
                    ht.Add("MemberNo", UserNo);
                    if (!api.Post("http://localhost:5000/insert/Note", ht))
                    {
                        MessageBox.Show("추가실패");
                    }
                    MessageBox.Show("공지사항 추가되었습니다.");
                    this.Dispose();
                    break;
                case "취소":
                    this.Dispose();
                    break;
                default:
                    break;
            }
        }

        private void Txt_Title_Leave(object sender, EventArgs e)
        {
            if (txt_Title.Text == "")
            {
                txt_Title.Text = "제목을 입력하세요";
                txt_Title.ForeColor = Color.Silver;
            }
        }

        private void Txt_Title_Enter(object sender, EventArgs e)
        {
            if (txt_Title.Text == "제목을 입력하세요")
            {
                txt_Title.Text = "";
                txt_Title.ForeColor = Color.Black;
            }
           
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            if (txt_content.Text == "")
            {
                txt_content.Text = "내용을 입력하세요";
                txt_content.ForeColor = Color.Silver;
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            if (txt_content.Text == "내용을 입력하세요")
            {
                txt_content.Text = "";
                txt_content.ForeColor = Color.Black;
            }
        }
    }
}
