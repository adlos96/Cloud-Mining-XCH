using System;
using System.Windows.Forms;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void Tutorial_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }
    }
}