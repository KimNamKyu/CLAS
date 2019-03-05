using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using CLASystem.Forms;
using Commons;
namespace CLASystem
{
    public partial class MainForm : Form
    {
        private LoginForm login;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
            
            if (FormLoad.GetLoad(this, "MDI"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name == "Content")
                    {
                        if (login != null) login.Dispose();
                        login = new LoginForm();
                        login.MdiParent = this;
                        login.BackColor = Color.Gray;
                        ctl.Controls.Add(login);
                        login.Show();
                        break;
                    }
                }
            }
            else
            {

            }
        }
    }
}
