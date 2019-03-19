using CLAprogram.Forms;
using CLAprogram.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAprogram.Models
{
    class Load
    {
        private Form parentForm;
        private string mNo;
        private string nTitle;
        private string Subject;
        private string Content;
        private FormLoad form;
        private string bNo;
  

        public Load(Form parentForm)
        {
            this.parentForm = parentForm;
        }

        public Load(Form parentForm,string bNo,string nTitle, string Subject, string Content)
        {
            this.bNo = bNo;
            this.parentForm = parentForm;
            this.nTitle = nTitle;
            this.Subject = Subject;
            this.Content = Content;
        }

        public Load(Form parentForm, string UserNo)
        {
            this.parentForm = parentForm;
            this.mNo = UserNo;
        }

       


        public EventHandler GetHandler(string viewName)
        {
            switch (viewName)
            {
                case "main":
                    return GetMainLoad;
                case "manage":
                    return GetManageLoad;
                case "DashBoard":
                    return GetDashBoardLoad;
                case "notice":
                    return GetNoticeLoad;
                case "userinfo":
                    return GetUserLoad;
                case "detail_info":
                    return GetDetailLoad;
                case "detail_write":
                    return GetDetailwriteLoad;
                case "Log_user":
                    return GetLog;
                case "LogReport":
                    return GetLogLoad;
                default:
                    return null;
            }
        }

        private void GetLogLoad(object sender, EventArgs e)
        {
            parentForm.Size = new Size(810, 830);
            parentForm.BackColor = Color.Gainsboro;
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "실시간 로그 기록 화면";
            new LogReportView(parentForm);
        }

        private void GetLog(object sender, EventArgs e)
        {
            parentForm.Size = new Size(810, 830);
            parentForm.BackColor = Color.Gainsboro;
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "로그 기록 상세 조회 화면";
            new LoguserView(parentForm, mNo);
        }

        private void GetDetailwriteLoad(object sender, EventArgs e)
        {
            parentForm.Size = new Size(810, 830);
            parentForm.BackColor = Color.Gainsboro;
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.StartPosition = FormStartPosition.CenterParent;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "글쓰기 화면";
            new DetailView(parentForm);
        }

        private void GetDetailLoad(object sender, EventArgs e)
        {
            parentForm.Size = new Size(810, 830);
            parentForm.BackColor = Color.Gainsboro;
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "게시물 상세 화면";
            new DetailView(parentForm,bNo,nTitle,Subject,Content);
        }

        private void GetDashBoardLoad(object sender, EventArgs e)
        {
            form = new FormLoad();
            form.GetLoad(parentForm, "SDI");
            parentForm.WindowState = FormWindowState.Maximized;
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new DashBoardView(parentForm);
        }

        private void GetNoticeLoad(object sender, EventArgs e)
        {
            form = new FormLoad();
            form.GetLoad(parentForm, "SDI");
            parentForm.WindowState = FormWindowState.Maximized;
            parentForm.FormBorderStyle = FormBorderStyle.None;
            new NoticeView(parentForm);
        }

        private void GetUserLoad(object sender, EventArgs e)
        {
            form = new FormLoad();
            form.GetLoad(parentForm, "SDI");
            parentForm.WindowState = FormWindowState.Maximized;
            parentForm.FormBorderStyle = FormBorderStyle.None;

            new UserView(parentForm);
        }

        private void GetManageLoad(object sender, EventArgs e)
        {
            parentForm.Size = new Size(1200, 900);
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "관리화면";
            form = new FormLoad();
            form.GetLoad(parentForm, "MDI");
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            new ManageView(parentForm);
        }

        private void GetMainLoad(object sender, EventArgs e)
        {
            parentForm.Size = new Size(800, 600);
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            //parentForm.MaximizeBox = false;
            //parentForm.MinimizeBox = false;
            parentForm.Text = "로그인 화면";
            new MainView(parentForm);
        }
    }
}
