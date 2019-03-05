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
    public partial class LoginForm : Form
    {
        private Common comm;
        private Panel pnl_group;
        private TextBox txt_box1;
        private Label lb_login;
        private Hashtable ht;
        private Button btn_group;

        public LoginForm()
        {
            InitializeComponent();
            Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            getView();
        }

        private void getView()
        {
            comm = new Common();

            if (FormLoad.GetLoad(this, "SDI"))
            {
                //공통패널
                ht = new Hashtable();
                ht.Add("size", new Size(600, 400));
                ht.Add("point", new Point(0, 0));
                ht.Add("color", Color.Gray);
                ht.Add("name", "group");
                pnl_group = comm.getPanel(ht);
                Controls.Add(pnl_group);

                /*==================================================*/

                //텍스트박스
                ht = new Hashtable();
                ht.Add("width", 300);
                ht.Add("font", new Font("Microsoft Sans Serif", 15));
                ht.Add("point", new Point(150, 100));
                ht.Add("name", "login_text");
                txt_box1 = comm.getTextBox(ht);
                pnl_group.Controls.Add(txt_box1);

                ht = new Hashtable();
                ht.Add("width", 300);
                ht.Add("font", new Font("Microsoft Sans Serif", 15));
                ht.Add("point", new Point(150, 150));
                ht.Add("name", "pwd_text");
                txt_box1 = comm.getTextBox(ht);
                pnl_group.Controls.Add(txt_box1);

                /*==================================================*/

                //로그인 로그아웃 라벨
                ht = new Hashtable();
                ht.Add("point", new Point(50, 100));
                ht.Add("color", Color.White);
                ht.Add("name", "login_lb");
                ht.Add("text", "로그인");
                lb_login = comm.getLabel(ht);
                pnl_group.Controls.Add(lb_login);

                ht = new Hashtable();
                ht.Add("point", new Point(50, 150));
                ht.Add("color", Color.White);
                ht.Add("name", "pwd_lb");
                ht.Add("text", "로그아웃");
                lb_login = comm.getLabel(ht);
                pnl_group.Controls.Add(lb_login);

                /*==================================================*/

                //버튼
                ht = new Hashtable();
                ht.Add("size", new Size(200, 100));
                ht.Add("point", new Point(200, 250));
                ht.Add("color", Color.SkyBlue);
                ht.Add("name", "btn_menu");
                ht.Add("text", "DashBoard");
                ht.Add("click", (EventHandler)btn_Click);
                btn_group = comm.getButton(ht);
                pnl_group.Controls.Add(btn_group);
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            middleView mv;
            this.Visible = false;
            //this.FormClosed += new FormClosedEventHandler(Exit_click);
            //this.Dispose();
            mv = new middleView();
            mv.Show();
            this.Close();
           
        }
        private void Exit_click(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
