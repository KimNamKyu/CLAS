using CLAprogram.Forms;
using CLAprogram.Models;
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
    class ManageView
    {
        private Form parentForm;
        private Commons comm;
        private Panel pnl_group;
        private Panel pnl_mdi;
        private Button btn_home;
        private Button btn_Dash;
        private Button btn_user;
        private Panel pnl_top;
        private Panel pnl_select;
        private Hashtable ht;
        private Button btn_Board;
        private PictureBox img;

        public ManageView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
            parentForm.FormClosed += new FormClosedEventHandler(Exit_click);
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(200, 900));
            ht.Add("point", new Point(0, 0));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht,parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(10, 100));
            ht.Add("point", new Point(0, 120));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "group");
            pnl_select = comm.getPanel(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(1200, 20));
            ht.Add("point", new Point(200, 0));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "group");
            pnl_top = comm.getPanel(ht, parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(1200, 900));
            ht.Add("point", new Point(200, 20));
            ht.Add("color", Color.Yellow);
            ht.Add("name", "group");
            pnl_mdi = comm.getPanel(ht,parentForm);

            ht = new Hashtable();
            ht.Add("image", (Bitmap)Properties.Resources.ResourceManager.GetObject("CLALogo"));
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(10, 10));
            img = comm.getPictureBox(ht, pnl_group);
            img.BackgroundImageLayout = ImageLayout.Stretch;

            ht = new Hashtable();
            ht.Add("size", new Size(190, 100));
            ht.Add("point", new Point(10, 120));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "home");
            ht.Add("text", "Home");
            ht.Add("click", (EventHandler)btn_Click);
            btn_home = comm.getButton(ht, pnl_group);
            btn_home.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn_home.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(190, 100));
            ht.Add("point", new Point(10, 230));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "btn_board");
            ht.Add("text", "DashBoard");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Dash = comm.getButton(ht, pnl_group);
            btn_Dash.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn_Dash.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(190, 100));
            ht.Add("point", new Point(10, 340));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "user");
            ht.Add("text", "사용자");
            ht.Add("click", (EventHandler)btn_Click);
            btn_user = comm.getButton(ht, pnl_group);
            btn_user.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn_user.ForeColor = Color.White;

            ht = new Hashtable();
            ht.Add("size", new Size(190, 100));
            ht.Add("point", new Point(10, 450));
            ht.Add("color", Color.FromArgb(0, 89, 171));
            ht.Add("name", "notice");
            ht.Add("text", "게시물");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);
            btn_Board.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn_Board.ForeColor = Color.White;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "home":
                    pnl_mdi.Controls.Clear();
                    pnl_select.Height = btn_home.Height;
                    pnl_select.Top = btn_home.Top;
                    btn_home.BringToFront();
                    break;

                case "btn_board":
                    pnl_select.Height = btn_Dash.Height;
                    pnl_select.Top = btn_Dash.Top;
                    btn_Dash.BringToFront();
                    DashBoardForm dbf = new DashBoardForm();
                    dbf.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(dbf);
                    dbf.Show();
                    break;

                case "user":
                    pnl_select.Height = btn_user.Height;
                    pnl_select.Top = btn_user.Top;
                    btn_user.BringToFront();
                    UserInfo user = new UserInfo();
                    user.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(user);
                    user.Show();
                    break;

                case "notice":
                    pnl_select.Height = btn_Board.Height;
                    pnl_select.Top = btn_Board.Top;
                    btn_Board.BringToFront();
                    NoticeInfo ni = new NoticeInfo();
                    ni.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(ni);
                    ni.Show();
                    break;
                default:
                    break;
            }
        }
        private void Exit_click(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
