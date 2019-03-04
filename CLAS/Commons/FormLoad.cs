using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons
{
    public class FormLoad
    {
        private static bool hm;     //상태값
        private static int mx, my;  // 마우스 X, Y값

        /// <summary>
        /// 화면 로드
        /// </summary>
        public static bool GetLoad(Form targetForm, string viewType)
        {
            targetForm.IsMdiContainer = true;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            Panel header = new Panel();
            header.Size = new Size(targetForm.Width, 50);
            header.Dock = DockStyle.Top;
            header.BackColor = Color.Gainsboro;
            header.Location = new Point(0, 0);

            // mouse 이벤트 => 상태값
            header.MouseDown += (a, b) =>
            {
                hm = true;
                mx = Cursor.Position.X - targetForm.Left;
                //MessageBox.Show(mx.ToString());
                my = Cursor.Position.Y - targetForm.Top;
                //MessageBox.Show(my.ToString());
            };
            header.MouseMove += (a, b) =>
            {
                if (hm)
                {
                    //마우스 위치를 알아야함. (X,Y축) => 역순
                    targetForm.Left = Cursor.Position.X - mx;
                    targetForm.Top = Cursor.Position.Y - my;
                }
            };
            header.MouseUp += (a, b) => { hm = false; };

            // 창 최대화
            header.MouseDoubleClick += (a, b) =>
            {
                if (targetForm.WindowState == FormWindowState.Maximized)
                {
                    targetForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    targetForm.WindowState = FormWindowState.Maximized;
                }
            };

            targetForm.Controls.Add(header);

            Label Close = new Label();
            Close.Size = new Size(33, 30);
            Close.Location = new Point(targetForm.Width - 40, 8);
            Close.Text = "X";
            Close.Font = new Font("굴림", 22, FontStyle.Bold);
            Close.Cursor = Cursors.Hand;
            Close.AutoSize = false;
            Close.Anchor = AnchorStyles.Right;
            //람다식! : ()함수 : 함수가 없다는 것은 익명 :: 두개의 매개변수 a, b
            Close.Click += (a, b) => { Application.Exit(); };
            header.Controls.Add(Close);



            switch (viewType)
            {
                case "MDI":
                    Panel Content = new Panel();
                    Content.Dock = DockStyle.Fill;
                    Content.Name = "Content";
                    Content.BackColor = Color.White;
                    targetForm.Controls.Add(Content);
                    return true;
                case "SDI":
                    targetForm.IsMdiContainer = false;
                    targetForm.FormBorderStyle = FormBorderStyle.None;
                    targetForm.Dock = DockStyle.Fill;
                    return true;
                default:
                    MessageBox.Show("누구냐?");
                    return false;
            }
        }
    }
}
