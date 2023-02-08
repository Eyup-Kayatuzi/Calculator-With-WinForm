using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev
{
    public partial class ForSquareRoot : Form
    {
        Form1 Form1;
        public ForSquareRoot(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Form1.Show();
            this.Close();

        }
    }
}
