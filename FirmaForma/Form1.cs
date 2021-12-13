using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FirmaForma
{
    public partial class Form1 : Form
    {
        string CS = "Data source = DESKTOP-HLB8M6E\\SQLEXPRESS; Initial catalog = Firma; Integrated security = true";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
