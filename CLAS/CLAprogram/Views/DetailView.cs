using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class DetailView
    {
        private Form parentForm;
        private Commons comm;
        private ComboBox comboCategory;
        private WebAPI api;
        private Hashtable ht;
        private Panel pnl_group;
        private Panel pnl_item;
        private Label lb_title;
        private Panel pnl_item_title;
        private TextBox txt_content;
        private string nTitle, Subject, Content, bNo; // 공지사항 넘버   // 상단분류 / 제목 / 내용
        private TextBox txt_Title;
        private Button btn_Board;
        private string[] arr;
        public string DvcNo;
        private string[] _cNo;

        public DetailView(Form parentForm,  string UserNo)
        {
            this.parentForm = parentForm;
            this.bNo = UserNo;
            comm = new Commons();
            getView();
            WriteGetView();
        }

        public DetailView(Form parentForm, string bNo, string nTitle, string Subject, string Content)
        {
            this.bNo = bNo;
            this.parentForm = parentForm;
            this.nTitle = nTitle;
            this.Subject = Subject;
            this.Content = Content;
            comm = new Commons();
            getView();
            DetailGetView();
        }


        private void getView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(760, 760));
            ht.Add("point", new Point(18, 17));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht,parentForm);
            pnl_group.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(758, 80));
            ht.Add("point", new Point(0, 0));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_item = comm.getPanel(ht,pnl_group);
            pnl_item.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("size", new Size(758, 678));
            ht.Add("point", new Point(0, 80));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_item_title = comm.getPanel(ht,pnl_group);
            pnl_item_title.BorderStyle = BorderStyle.FixedSingle;

        }
        private void DetailGetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(410, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "등록");
            ht.Add("text", "등록");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_item);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(520, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "수정");
            ht.Add("text", "수정");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_item);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(630, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "취소");
            ht.Add("text", "취소");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_item);

            ht = new Hashtable();
            ht.Add("point", new Point(10, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "분류");
            lb_title = comm.getLabel(ht, pnl_item);
            lb_title.Font = new Font("Microsoft Sans Serif", 30);
            lb_title.Size = new Size(300, 50);
            lb_title.Text = nTitle;

           
            ht = new Hashtable();
            ht.Add("point", new Point(28, 15));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "title");
            ht.Add("text", "제목 받아와서 넣기");
            lb_title = comm.getLabel(ht, pnl_item_title);
            lb_title.Font = new Font("Microsoft Sans Serif", 25);
            lb_title.Size = new Size(700, 60);
            lb_title.Text = Subject;

            ht = new Hashtable();
            ht.Add("width", 700);
            ht.Add("font", new Font("Microsoft Sans Serif", 25));
            ht.Add("point", new Point(28, 15));
            ht.Add("name", "제목");
            txt_Title = comm.getTextBox(ht, pnl_item_title);
            txt_Title.Multiline = true;
            txt_Title.Height = 50;
            txt_Title.BorderStyle = BorderStyle.FixedSingle;
            txt_Title.ForeColor = Color.Black;
            txt_Title.Enter += Txt_Title_Enter;
            txt_Title.Leave += Txt_Title_Leave;
            txt_Title.Visible = false;

            ht = new Hashtable();
            ht.Add("width", 700);
            ht.Add("font", new Font("Microsoft Sans Serif", 20));
            ht.Add("point", new Point(28, 80));
            ht.Add("name", "내용");
            txt_content = comm.getTextBox(ht, pnl_item_title);
            txt_content.Multiline = true;
            txt_content.Height = 400;
            txt_content.Enabled = false;
            txt_content.Enter += Txt_Enter;
            txt_content.Leave += Txt_Leave;
            txt_content.ForeColor = Color.Black;
            txt_content.BorderStyle = BorderStyle.FixedSingle;
            txt_content.Text = Content;
            pnl_item_title.Controls.Add(txt_content);
        }


        private void WriteGetView()
        {
            
            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(520, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "저장");
            ht.Add("text", "저장");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_item);

            ht = new Hashtable();
            ht.Add("size", new Size(100, 60));
            ht.Add("point", new Point(630, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "취소");
            ht.Add("text", "취소");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_item);

            ht = new Hashtable();
            ht.Add("width", 700);
            ht.Add("font", new Font("Microsoft Sans Serif", 25));
            ht.Add("point", new Point(28, 15));
            ht.Add("name", "제목");
            txt_Title = comm.getTextBox(ht, pnl_item_title);
            txt_Title.Multiline = true;
            txt_Title.Height = 50;
            txt_Title.BorderStyle = BorderStyle.FixedSingle;
            txt_Title.ForeColor = Color.Black;
            txt_Title.Enter += Txt_Title_Enter;
            txt_Title.Leave += Txt_Title_Leave;
            

            ht = new Hashtable();
            ht.Add("width", 700);
            ht.Add("font", new Font("Microsoft Sans Serif", 20));
            ht.Add("point", new Point(28, 80));
            ht.Add("name", "내용");
            txt_content = comm.getTextBox(ht, pnl_item_title);
            txt_content.Multiline = true;
            txt_content.Height = 400;

            txt_content.Enabled = true;
            txt_content.Enter += Txt_Enter;
            txt_content.Leave += Txt_Leave;
            txt_content.BorderStyle = BorderStyle.FixedSingle;
            Content = txt_content.Text;



            ht = new Hashtable();
            ht.Add("width", 300);
            ht.Add("point", new Point(40, 30));
            ht.Add("color", Color.Gainsboro);
            ht.Add("font", new Font("맑은고딕", 14, FontStyle.Bold));
            ht.Add("name", "comboCategory");
            comboCategory = comm.getComboBox(ht, pnl_item);
            api = new WebAPI();
            ArrayList list = api.SelectCategory("http://localhost:5000/select/Category");
            
            arr = new string[list.Count];
            _cNo = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                JArray j = (JArray)list[i];
                _cNo[i] = j.Value<string>(0).ToString();
                arr[i] = j.Value<string>(1).ToString();
            }

            comboCategory.SelectedIndexChanged += ComboCategory_SelectedIndexChanged;
            comboCategory.Items.AddRange(arr);
            comboCategory.Font = new Font("맑은 고딕", 13, FontStyle.Bold);
        }

        private void ComboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    DvcNo = _cNo[0];
                    break;
                case 1:
                    DvcNo = _cNo[1];
                    break;
                case 2:
                    DvcNo = _cNo[2];
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
                case "저장":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("spName", "Board_Insert_proc");
                    ht.Add("cNo", DvcNo);
                    ht.Add("bTitle", txt_Title.Text);
                    ht.Add("bContents", txt_content.Text);
                    ht.Add("MemberNo", bNo);
                    if (!api.Post("http://localhost:5000/insert/Note", ht))
                    {
                        MessageBox.Show("추가실패");
                    }
                    MessageBox.Show("공지사항 추가되었습니다.");
                    parentForm.Dispose();
                    break;
                case "등록":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("bNo", bNo);
                    ht.Add("bTitle", txt_Title.Text);
                    ht.Add("bContents", txt_content.Text);
                    if (!api.Post("http://localhost:5000/update/Noteinfo", ht))
                    {
                        MessageBox.Show("수정실패");
                    }
                    
                    parentForm.Dispose();
                    break;
                case "수정":
                    lb_title.Visible = false;
                    txt_content.Enabled = true;
                    txt_Title.Visible = true;
                    break;
                case "취소":
                    parentForm.Dispose();
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
