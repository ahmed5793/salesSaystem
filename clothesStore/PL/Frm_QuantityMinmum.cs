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
    public partial class Frm_QuantityMinmum : Form
    {
        Proudect p = new Proudect();
        Store Store = new Store();
        public Frm_QuantityMinmum()
        {
            InitializeComponent();
            gridControl1.DataSource = p.SelectMinmun();

        }
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Frm_QuantityMinmum_Load(object sender, EventArgs e)
        {
            

            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //gridControl1.DataSource = p.SelectMinmun(Convert.ToInt32(Cmb_Store.SelectedValue));
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
