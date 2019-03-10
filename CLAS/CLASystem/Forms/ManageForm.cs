using Commons;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLASystem.Forms
{
    public partial class ManageForm : Form
    {
        private Common comm;
        private Hashtable ht;
        private Button btn_Board;
        private Panel pnl_group, pnl_mdi;
        private DashBoardForm board;
        private UserInfo user;
        private NoticeInfo notice;
        private Label lb_login;

        public ManageForm()
        {
            InitializeComponent();
            Load += ManageForm_Load;
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 800);
            getView();
        }

        private void getView()
        {
            if (FormLoad.GetLoad(this, "MDI"))
            {
                foreach (Control ctl in this.Controls)
                {
                    comm = new Common();
                    if (ctl.Name == "Content")
                    {
                        ht = new Hashtable();
                        ht.Add("size", new Size(200, 800));
                        ht.Add("point", new Point(0, 0));
                        ht.Add("color", Color.WhiteSmoke);
                        ht.Add("name", "group");
                        pnl_group = comm.getPanel(ht);
                        ctl.Controls.Add(pnl_group);

                        ht = new Hashtable();
                        ht.Add("size", new Size(1200, 800));
                        ht.Add("point", new Point(200, 0));
                        ht.Add("color", Color.Yellow);
                        ht.Add("name", "group");
                        pnl_mdi = comm.getPanel(ht);
                        ctl.Controls.Add(pnl_mdi);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 100));
                        ht.Add("point", new Point(10, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "home");
                        ht.Add("text", "Home");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 100));
                        ht.Add("point", new Point(10, 120));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "btn_board");
                        ht.Add("text", "DashBoard");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 100));
                        ht.Add("point", new Point(10, 230));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "user");
                        ht.Add("text", "사용자");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 100));
                        ht.Add("point", new Point(10, 340));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "notice");
                        ht.Add("text", "게시물");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);


                        ht = new Hashtable();
                        ht.Add("point", new Point(250, 50));
                        ht.Add("color", Color.White);
                        ht.Add("name", "login_lb");
                        ht.Add("text", "메인 홈");
                        lb_login = comm.getLabel(ht);
                        pnl_mdi.Controls.Add(lb_login);
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "home":
                    pnl_mdi.Controls.Clear();
                    break;
                case "btn_board":
                    if (FormLoad.GetLoad(board = new DashBoardForm(), "SDI"))
                    {
                        board.MdiParent = this;
                        board.WindowState = FormWindowState.Maximized;
                        board.FormBorderStyle = FormBorderStyle.None;
                        pnl_mdi.Controls.Add(board);
                        board.Show();
                    }
                    break;

                case "user":
                    if (FormLoad.GetLoad(user = new UserInfo(), "SDI"))
                    {
                        user.MdiParent = this;
                        user.WindowState = FormWindowState.Maximized;
                        user.FormBorderStyle = FormBorderStyle.None;
                        pnl_mdi.Controls.Add(user);
                        user.Show();
                    }
                    break;

                case "notice":
                    if (FormLoad.GetLoad(notice = new NoticeInfo(), "SDI"))
                    {
                        //notice.TopLevel = false;
                        notice.MdiParent = this;
                        notice.WindowState = FormWindowState.Maximized;
                        notice.FormBorderStyle = FormBorderStyle.None;
                        pnl_mdi.Controls.Add(notice);
                        notice.Show();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
