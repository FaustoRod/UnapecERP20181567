using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnapecERPApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new ProveedorMantenForm().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new ConceptoPagoMantenForm().ShowDialog();
        }
    }
}
