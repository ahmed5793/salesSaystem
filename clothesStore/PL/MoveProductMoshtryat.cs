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
    public partial class MoveProductMoshtryat : Form
    {
        Proudect p = new Proudect();

        public MoveProductMoshtryat()
        {
            InitializeComponent();
            gridControl1.DataSource = p.SelectMoveProductMoshtryat();

        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
