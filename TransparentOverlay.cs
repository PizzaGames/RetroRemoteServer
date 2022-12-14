using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroRemoteServer
{
    public partial class TransparentOverlay : Form
    {
        public TransparentOverlay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TransparentOverlay_Activated(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void TransparentOverlay_Deactivate(object sender, EventArgs e)
        {
            Cursor.Show();
        }
    }
}
