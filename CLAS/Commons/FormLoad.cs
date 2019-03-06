using System.Drawing;
using System.Windows.Forms;

namespace Commons
{
    public class FormLoad
    {
        public static bool GetLoad(Form targetForm, string viewType)
        {
            switch (viewType)
            {
                case "MDI":
                    targetForm.IsMdiContainer = true;
                    targetForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    Panel Content = new Panel();
                    Content.Dock = DockStyle.Fill;
                    Content.Name = "Content";
                    Content.BackColor = Color.Yellow;
                    targetForm.Controls.Add(Content);
                    return true;
                case "SDI":
                    targetForm.IsMdiContainer = false;
                    targetForm.FormBorderStyle = FormBorderStyle.None;
                    targetForm.Dock = DockStyle.Fill;
                    return true;
                default:
                    return false;
            }
        }
    }
}
