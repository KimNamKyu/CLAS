﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using CLASystem.Forms;
using Commons;
namespace CLASystem
{
    public partial class MainForm : Form
    {
        private Common comm;
        private Panel pnl_group;
        private TextBox txt_box1;
        private Label lb_login;
        private Hashtable ht;
        private Button btn_group;
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(550, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            getView();
        }

        private void getView()
        {
            comm = new Common();

            
                //공통패널
                ht = new Hashtable();
                ht.Add("size", new Size(550, 450));
                ht.Add("point", new Point(0, 0));
                ht.Add("color", Color.WhiteSmoke);
                ht.Add("name", "group");
                pnl_group = comm.getPanel(ht);
                Controls.Add(pnl_group);

                /*==================================================*/

                //텍스트박스
                ht = new Hashtable();
                ht.Add("width", 250);
                ht.Add("font", new Font("Microsoft Sans Serif", 18));
                ht.Add("point", new Point(200, 150));
                ht.Add("name", "login_text");
                txt_box1 = comm.getTextBox(ht);
                pnl_group.Controls.Add(txt_box1);

                ht = new Hashtable();
                ht.Add("width", 250);
                ht.Add("font", new Font("Microsoft Sans Serif", 18));
                ht.Add("point", new Point(200, 200));
                ht.Add("name", "pwd_text");
                txt_box1 = comm.getTextBox(ht);
                pnl_group.Controls.Add(txt_box1);

                /*==================================================*/

                //로그인 로그아웃 라벨
                ht = new Hashtable();
                ht.Add("point", new Point(200, 50));
                ht.Add("color", Color.WhiteSmoke);
                ht.Add("name", "login_lb");
                ht.Add("text", "관리자 로그인");
                lb_login = comm.getLabel(ht);
                lb_login.Font = new Font("Microsoft Sans Serif", 25);
                lb_login.Size = new Size(200, 40);
                pnl_group.Controls.Add(lb_login);

                ht = new Hashtable();
                ht.Add("point", new Point(100, 150));
                ht.Add("color", Color.WhiteSmoke);
                ht.Add("name", "login_lb");
                ht.Add("text", "로그인");
                lb_login = comm.getLabel(ht);
            lb_login.Font = new Font("Microsoft Sans Serif", 18);
            lb_login.Size = new Size(100, 25);
            pnl_group.Controls.Add(lb_login);

                ht = new Hashtable();
                ht.Add("point", new Point(100, 200));
                ht.Add("color", Color.WhiteSmoke);
                ht.Add("name", "pwd_lb");
                ht.Add("text", "로그아웃");
                lb_login = comm.getLabel(ht);
            lb_login.Font = new Font("Microsoft Sans Serif", 18);
            lb_login.Size = new Size(100, 25);
            pnl_group.Controls.Add(lb_login);

                /*==================================================*/

                //버튼
                ht = new Hashtable();
                ht.Add("size", new Size(350, 40));
                ht.Add("point", new Point(100, 250));
                ht.Add("color", Color.SkyBlue);
                ht.Add("name", "btn_menu");
                ht.Add("text", "로그인");
                ht.Add("click", (EventHandler)btn_Click);
                btn_group = comm.getButton(ht);
                pnl_group.Controls.Add(btn_group);
            

        }

        private void btn_Click(object sender, EventArgs e)
        {
            ManageForm mf;
            mf = new ManageForm();
            mf.Show();

            //this.Visible = false;
            //this.FormClosed += new FormClosedEventHandler(Exit_click);
        }
    }
}
