using CLASystem.Forms;
using Commons;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CLASystem
{
    public partial class middleView : Form
    {
        private Common comm;
        private Hashtable ht;
        private Button btn_Board;
        private Panel pnl_group, pnl_mdi;
        private DashBoardForm board;
        private UserInfo user;
        private NoticeInfo notice;
        private Label lb_login;
        private Button btn_home;
        private Button btn_Dash;
        private Button btn_user;

        public middleView()
        {
            InitializeComponent();
            Load += MiddleView_Load;
        }

        private void MiddleView_Load(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            this.Size = new Size(1200, 900);
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
                        ht.Add("size", new Size(1200, 130));
                        ht.Add("point", new Point(0, 0));
                        ht.Add("color", Color.DimGray);
                        ht.Add("name", "group");
                        pnl_group = comm.getPanel(ht);
                        ctl.Controls.Add(pnl_group);

                        ht = new Hashtable();
                        ht.Add("size", new Size(1200, 730));
                        ht.Add("point", new Point(0, 130));
                        ht.Add("color", Color.Yellow);
                        ht.Add("name", "group");
                        pnl_mdi = comm.getPanel(ht);
                        ctl.Controls.Add(pnl_mdi);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 110));
                        ht.Add("point", new Point(10, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "home");
                        ht.Add("text", "Logo");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 110));
                        ht.Add("point", new Point(200, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "home");
                        ht.Add("text", "Home");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_home = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_home);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 110));
                        ht.Add("point", new Point(390, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "btn_board");
                        ht.Add("text", "DashBoard");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Dash = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Dash);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 110));
                        ht.Add("point", new Point(580, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "user");
                        ht.Add("text", "사용자");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_user = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_user);

                        ht = new Hashtable();
                        ht.Add("size", new Size(180, 110));
                        ht.Add("point", new Point(770, 10));
                        ht.Add("color", Color.Gainsboro);
                        ht.Add("name", "notice");
                        ht.Add("text", "게시물");
                        ht.Add("click", (EventHandler)btn_Click);
                        btn_Board = comm.getButton(ht);
                        pnl_group.Controls.Add(btn_Board);
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
                    btn_home.BackColor = Color.RoyalBlue;
                    btn_Dash.BackColor = Color.Gainsboro;
                    btn_user.BackColor = Color.Gainsboro;
                    btn_Board.BackColor = Color.Gainsboro;
                    break;
                case "btn_board":
                    
                    if (FormLoad.GetLoad(board = new DashBoardForm(), "SDI"))
                    {
                        btn_home.BackColor = Color.Gainsboro;
                        btn_Dash.BackColor = Color.RoyalBlue;
                        btn_user.BackColor = Color.Gainsboro;
                        btn_Board.BackColor = Color.Gainsboro;
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
                        btn_home.BackColor = Color.Gainsboro;
                        btn_Dash.BackColor = Color.Gainsboro;
                        btn_user.BackColor = Color.RoyalBlue;
                        btn_Board.BackColor = Color.Gainsboro;
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
                        btn_home.BackColor = Color.Gainsboro;
                        btn_Dash.BackColor = Color.Gainsboro;
                        btn_user.BackColor = Color.Gainsboro;
                        btn_Board.BackColor = Color.RoyalBlue;
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
