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
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("manage");
        }

        public ManageForm(Form _form)
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("manage");
        }

    }
}
