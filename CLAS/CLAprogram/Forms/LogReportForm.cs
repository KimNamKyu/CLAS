using CLAprogram.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAprogram.Forms
{
    public partial class LogReportForm : Form
    {
        public LogReportForm()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("LogReport");
        }
    }
}
