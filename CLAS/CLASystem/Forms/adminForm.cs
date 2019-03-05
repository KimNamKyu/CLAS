using CLASystem.Forms;
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

namespace CLASystem
{
    public partial class middleView : Form
    {
        private Common comm;
        private Hashtable ht;
        private Button btn_Board;
        private Panel pnl_group, pnl_mdi;

        public middleView()
        {
            InitializeComponent();
            Load += MiddleView_Load;
        }

        private void MiddleView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1400, 800);
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
                        ht.Add("name", "Logo");
                        ht.Add("text", "DashBoard");
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

                    }
                }
            }
           
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DashBoardForm board;
            UserInfo user;
            NoticeInfo notice;
            switch (btn.Name)
            {
                case "btn_board":
                    if (FormLoad.GetLoad(board = new DashBoardForm(), "SDI"))
                    {
                        board.TopLevel = false;
                        pnl_mdi.Controls.Add(board);
                        board.Show();
                    }
                    break;

                case "user":
                    if (FormLoad.GetLoad(user = new UserInfo(), "SDI"))
                    {
                        user.TopLevel = false;
                        pnl_mdi.Controls.Add(user);
                        user.Show();
                    }
                    break;

                case "notice":
                    if (FormLoad.GetLoad(notice = new NoticeInfo(), "SDI"))
                    {
                        notice.TopLevel = false;
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
