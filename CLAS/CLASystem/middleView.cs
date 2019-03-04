using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASystem
{
    public partial class middleView : Form
    {
        private Common comm;
        private Hashtable ht;
        private Button btn_Board;
        private middleView mv;

        public middleView()
        {
            InitializeComponent();
            Load += MiddleView_Load;
        }

        private void MiddleView_Load(object sender, EventArgs e)
        {
            getView();
        }

        private void getView()
        {
            comm = new Common();
            ht = new Hashtable();
            ht.Add("size", new Size(100, 100));
            ht.Add("point", new Point(0, 10));
            ht.Add("color", Color.Gainsboro);
            ht.Add("name", "btn_board");
            ht.Add("text", "DashBoard");
            ht.Add("click", (EventHandler)btn_Click);
            btn_Board = comm.getButton(ht);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            mv = new middleView();
            this.Dispose();
            mv.Show();
        }
    }
}
