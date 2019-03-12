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
    public partial class Detail_Info : Form
    {
        public Detail_Info(string nTitle, string Subject, string Content)
        {
            InitializeComponent();
            Load load = new Load(this, nTitle,Subject,Content);
            Load += load.GetHandler("detail_info");
        }

        public Detail_Info(string cNo, string UserNo)
        {
            Load load = new Load(this,cNo,UserNo);
            Load += load.GetHandler("detail_write");
        }
    }
}
