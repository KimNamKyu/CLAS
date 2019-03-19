using System;
using System.Drawing;
using System.Windows.Forms;


namespace CLAprogram.Models
{
    class FormLoad
    {
        public bool GetLoad(Form targetForm, string viewType)
        {
            switch (viewType)
            {
                case "MDI":
                    targetForm.IsMdiContainer = true;
                    targetForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    
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
