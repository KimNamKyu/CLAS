using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Commons;
namespace CLASystem
{
    public partial class MainForm : Form
    {
        private Common comm;
        private Panel pnl_group;
        private Hashtable ht;
        private Button btn_Board;
        private TextBox tb_box;
        private Label lb_login;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.Size = new Size(1080, 800);
            //if (FormLoad.GetLoad(this, "MDI"))
            //{
            //    foreach (Control ctl in this.Controls)
            //    {
            //        if (ctl.Name == "Content")
            //        {
            //            if (mv != null) mv.Dispose();
            //            mv = new middleView();
            //            mv.MdiParent = this;
            //            mv.FormBorderStyle = FormBorderStyle.None;
            //            mv.BackColor = Color.White;
            //            ctl.Controls.Add(mv);
            //            mv.Show();
            //            break;
            //        }
            //    }
            //}
            //else
            //{

            //}

            getView();
            

        }

        private void getView()
        {
            this.Size = new Size(800, 600);
            if (FormLoad.GetLoad(this, "MDI"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name == "Content")
                    {
                        comm = new Common();

                        //공통패널
                        ht = new Hashtable();
                        ht.Add("size", new Size(600, 400));
                        ht.Add("point", new Point(100, 100));
                        ht.Add("color", Color.WhiteSmoke);
                        ht.Add("name", "group");
                        pnl_group = comm.getPanel(ht);
                        
                        /*==================================================*/
                        
                        //텍스트박스
                        ht = new Hashtable();
                        ht.Add("width", 300);
                        ht.Add("font", new Font("Microsoft Sans Serif", 15));
                        ht.Add("point", new Point(150, 100));
                        ht.Add("name", "login_text");
                        tb_box = comm.getTextBox(ht);
                        pnl_group.Controls.Add(tb_box);
                        ctl.Controls.Add(pnl_group);

                        ht = new Hashtable();
                        ht.Add("width", 300);
                        ht.Add("font", new Font("Microsoft Sans Serif", 15));
                        ht.Add("point", new Point(150, 150));
                        ht.Add("name", "pwd_text");
                        tb_box = comm.getTextBox(ht);
                        pnl_group.Controls.Add(tb_box);
                        ctl.Controls.Add(pnl_group);

                        /*==================================================*/

                        //로그인 로그아웃 라벨
                        ht = new Hashtable();
                        ht.Add("point", new Point(50, 100));
                        ht.Add("color", Color.White);
                        ht.Add("name", "login_lb");
                        ht.Add("text", "로그인");
                        lb_login = comm.getLabel(ht);
                        pnl_group.Controls.Add(lb_login);
                        ctl.Controls.Add(pnl_group);

                        ht = new Hashtable();
                        ht.Add("point", new Point(50, 150));
                        ht.Add("color", Color.White);
                        ht.Add("name", "pwd_lb");
                        ht.Add("text", "로그아웃");
                        lb_login = comm.getLabel(ht);
                        pnl_group.Controls.Add(lb_login);
                        ctl.Controls.Add(pnl_group);

                        /*==================================================*/

                        //버튼
                        ht = new Hashtable();
                        ht.Add("size", new Size(200, 100));
                        ht.Add("point", new Point(200, 250));
                        ht.Add("color", Color.SkyBlue);
                        ht.Add("name", "btn_menu");
                        ht.Add("text", "DashBoard");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);
                        ctl.Controls.Add(pnl_group);
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
