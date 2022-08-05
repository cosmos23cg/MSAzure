using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpVisionAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRemote_Click(object sender, EventArgs e)
        {
            frmRemote f = new frmRemote();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            frmLocal f = new frmLocal();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnReadAPI_Click(object sender, EventArgs e)
        {
            frmReadAPI f = new frmReadAPI();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnOCRAPI_Click(object sender, EventArgs e)
        {
            frmOCRAPI f = new frmOCRAPI();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
