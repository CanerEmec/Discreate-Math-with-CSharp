using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyrikMatematik_14067035_CanerEmec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CmbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prepare4Method(cmbMethods.SelectedIndex);
        }
    }
}
