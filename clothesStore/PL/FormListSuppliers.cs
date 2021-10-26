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
    public partial class FormListSuppliers : Form
    {
        Suppliers s = new Suppliers();
        public FormListSuppliers()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.ListSuppliers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();        
            dt= s.SearchListSuppliers(textBox1.Text);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            this.Close();
          
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView1.DataSource = null;
            this.Close();
        }

        private void FormListSuppliers_Load(object sender, EventArgs e)
        {

        }
    }
}
