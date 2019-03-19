using CLAprogram.Forms;
using CLAprogram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAprogram.Views
{
    class MainView
    {
        private Form parentForm;
        private Commons comm;
        private Panel pn_left;
        private Panel pn_center;
        private WebAPI api;
        private PictureBox img;
        private Hashtable ht;
        private Panel pn_right;
        private Label lb_login;
        private TextBox txt_login;
        private TextBox txt_pwd;
        private Button btn_login;
        private ManageForm targetForm;
        private Label lb_logo;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(400, 600));
            ht.Add("point", new Point(0, 0));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "left");
            pn_left = comm.getPanel(ht, parentForm);

            //Log analysis system
            //====================================================

            ht = new Hashtable();
            ht.Add("image", (Bitmap)Properties.Resources.ResourceManager.GetObject("CLALogo"));
            ht.Add("point", new Point(50,70));
            ht.Add("size", new Size(300,300));
            img = comm.getPictureBox(ht,pn_left);
            //img.BorderStyle = BorderStyle.FixedSingle;
            img.BackgroundImageLayout = ImageLayout.Stretch;

            ht = new Hashtable();
            ht.Add("point", new Point(25, 220));
            ht.Add("name", "login_lb");
            ht.Add("text", "Log Analysis System");
            lb_logo = comm.getLabel(ht, img);
            lb_logo.Font = new Font("Microsoft Sans Serif", 20);
            lb_logo.ForeColor = Color.White;

            //====================================================
            ht = new Hashtable();
            ht.Add("size", new Size(400, 600));
            ht.Add("point", new Point(400, 0));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "right");
            pn_right = comm.getPanel(ht, parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(330, 510));
            ht.Add("point", new Point(25, 25));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "center");
            pn_center = comm.getPanel(ht, pn_right);
            pn_center.BorderStyle = BorderStyle.FixedSingle;

            ht = new Hashtable();
            ht.Add("point", new Point(80, 25));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "login_lb");
            ht.Add("text", "관리자 로그인");
            lb_login = comm.getLabel(ht, pn_center);
            lb_login.Font = new Font("Microsoft Sans Serif", 25);

            //====================================================
            ht = new Hashtable();
            ht.Add("point", new Point(15, 100));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "login_lb");
            ht.Add("text", "Admin ID :");
            lb_login = comm.getLabel(ht, pn_center);
            lb_login.Font = new Font("Microsoft Sans Serif", 20);
            lb_login.Size = new Size(200, 40);

            ht = new Hashtable();
            ht.Add("width", 300);
            ht.Add("font", new Font("Microsoft Sans Serif", 20));
            ht.Add("point", new Point(15, 150));
            ht.Add("name", "login_text");
            txt_login = comm.getTextBox(ht, pn_center);

            //====================================================

            ht = new Hashtable();
            ht.Add("point", new Point(15, 220));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "login_pwd");
            ht.Add("text", "Password :");
            lb_login = comm.getLabel(ht, pn_center);
            lb_login.Font = new Font("Microsoft Sans Serif", 20);
            lb_login.Size = new Size(200, 40);

            ht = new Hashtable();
            ht.Add("width", 300);
            ht.Add("font", new Font("Microsoft Sans Serif", 20));
            ht.Add("point", new Point(15, 270));
            ht.Add("name", "pwd_text");
            txt_pwd = comm.getTextBox(ht, pn_center);
            txt_pwd.PasswordChar = '●';

            //====================================================

            ht = new Hashtable();
            ht.Add("size", new Size(300, 40));
            ht.Add("point", new Point(15, 350));
            ht.Add("color", Color.SkyBlue);
            ht.Add("name", "btn_menu");
            ht.Add("text", "로그인");
            ht.Add("click", (EventHandler)btn_Click);
            btn_login = comm.getButton(ht, pn_center);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "AdminLogin");
            ht.Add("param", "");
            //ht.Add("id", txt_box1.Text);
            //ht.Add("pwd", txt_box2.Text);
            ArrayList list = api.Select(Program.serverUrl + "select", ht);

            ArrayList result = new ArrayList();
            JObject jo = (JObject)list[0];

            string id = jo["MemberId"].ToString();
            string pwd = jo["MemberPassword"].ToString();
            MessageBox.Show(id +" : "+ pwd);

            if (id == txt_login.Text && pwd == txt_pwd.Text)
            {
                targetForm = new ManageForm();
                this.parentForm.Hide();
                targetForm.StartPosition = FormStartPosition.CenterScreen;
                //tagetForm.FormClosed += new FormClosedEventHandler(Exit_click);
                targetForm.Show();
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 확인해주세요 ");
            }

        }
        private void Exit_click(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Close();
        }
    }
}
