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
    public partial class Form_DebitSupplier : Form
    {
        Suppliers s = new Suppliers();

        public Form_DebitSupplier()
        {
            InitializeComponent();
            gridControl1.DataSource = s.Select_DepitSupplier();
            calc();
        }
        void calc()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(row[2].ToString());

            }
            txt_reb7h.Text = Math.Round(total, 2).ToString();

        }

        private void Form_DebitSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
