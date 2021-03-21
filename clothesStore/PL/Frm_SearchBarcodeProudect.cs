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
    public partial class Frm_SearchBarcodeProudect : Form
    {
        Proudect p = new Proudect();
        DataTable dt = new DataTable();
        public Frm_SearchBarcodeProudect()
        {
            InitializeComponent();
        }

        private void Frm_SearchBarcodeProudect_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = p.selectProudect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            dt = p.searchForProductBarcode(textBox1.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
