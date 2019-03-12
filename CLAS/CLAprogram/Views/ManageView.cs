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
        private Hashtable ht;
        private Button btn_Board;

        public ManageView(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            GetView();
        }

        private void GetView()
        {
            ht = new Hashtable();
            ht.Add("size", new Size(200, 900));
            ht.Add("point", new Point(0, 0));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "group");
            pnl_group = comm.getPanel(ht,parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(1200, 900));
            ht.Add("point", new Point(200, 0));
            ht.Add("color", Color.Yellow);
            ht.Add("name", "group");
            pnl_mdi = comm.getPanel(ht,parentForm);

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(10, 10));
            ht.Add("color", Color.WhiteSmoke);
            ht.Add("name", "home");
            ht.Add("text", "Home");
            ht.Add("click", null);
            btn_home = comm.getButton(ht, pnl_group);
            btn_home.Cursor = Cursors.Default;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.CausesValidation = false;

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(10, 120));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "btn_board");
            ht.Add("text", "DashBoard");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Dash = comm.getButton(ht, pnl_group);

            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(10, 230));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "user");
            ht.Add("text", "사용자");
            ht.Add("click", (EventHandler)btn_Click);
            btn_user = comm.getButton(ht, pnl_group);


            ht = new Hashtable();
            ht.Add("size", new Size(180, 100));
            ht.Add("point", new Point(10, 340));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "notice");
            ht.Add("text", "게시물");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht, pnl_group);

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                //case "home":
                //    pnl_mdi.Controls.Clear();
                //    btn_home.BackColor = Color.RoyalBlue;
                //    btn_Dash.BackColor = Color.Gainsboro;
                //    btn_user.BackColor = Color.Gainsboro;
                //    btn_Board.BackColor = Color.Gainsboro;
                //    break;

                case "btn_board":
                    btn_home.BackColor = Color.Gainsboro;
                    btn_Dash.BackColor = Color.RoyalBlue;
                    btn_user.BackColor = Color.Gainsboro;
                    btn_Board.BackColor = Color.Gainsboro;

                    DashBoardForm dbf = new DashBoardForm();
                    dbf.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(dbf);
                    dbf.Show();
                    break;

                case "user":
                    btn_home.BackColor = Color.Gainsboro;
                    btn_Dash.BackColor = Color.Gainsboro;
                    btn_user.BackColor = Color.RoyalBlue;
                    btn_Board.BackColor = Color.Gainsboro;

                    UserInfo user = new UserInfo();
                    user.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(user);
                    user.Show();
                    break;

                case "notice":

                    btn_home.BackColor = Color.Gainsboro;
                    btn_Dash.BackColor = Color.Gainsboro;
                    btn_user.BackColor = Color.Gainsboro;
                    btn_Board.BackColor = Color.RoyalBlue;

                    NoticeInfo ni = new NoticeInfo();
                    ni.MdiParent = parentForm;
                    pnl_mdi.Controls.Add(ni);
                    ni.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
