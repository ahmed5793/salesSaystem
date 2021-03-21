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
    public partial class Frm_MoveProduct : Form
    {
        Proudect p = new Proudect();
        public Frm_MoveProduct()
        {
            InitializeComponent();
            gridControl1.DataSource = p.SelectMovePorduct();
        }

        private void Frm_MoveProduct_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = p.SearchMovePorduct((DateFrom.Value), DateTo.Value);
            gridControl1.DataSource = dt;

        }
    }
}
