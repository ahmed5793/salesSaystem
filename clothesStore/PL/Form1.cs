using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clothesStore.Bl;

namespace clothesStore.PL
{
    public partial class Form1 : Form
    {
        Suppliers s = new Suppliers();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = s.SelectSuppliers();
            comboBox1.DisplayMember = "Sup_Name"         ;
           comboBox1.ValueMember = "Suppliers_id";


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
