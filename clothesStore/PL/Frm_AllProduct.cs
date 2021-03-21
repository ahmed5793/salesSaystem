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
    public partial class Frm_AllProduct : Form
    {
       Proudect p =new Proudect();
        Store Store = new Store();
        public Frm_AllProduct()
        {
            InitializeComponent();
            //ComboStore();
            gridControl1.DataSource = p.PrintAllProudects();
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[7].Visible = false;
            //gridView1.Columns[6].Visible = false;
            //gridView1.Columns[7].Visible = false;
            //gridView1.Columns[8].Visible = false;
            calcTotalSelling();
            calcTotalPurshacing();
            reb7();
        }
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        void reb7()
        {
            decimal reb7 = Convert.ToDecimal(txt_TotalSelling.Text) - Convert.ToDecimal(txt_TotalPurshacing.Text);
            textBox2.Text = reb7.ToString();
        }
        void calcTotalSelling()
        {
            Decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(r[7].ToString());
            }
            txt_TotalSelling.Text = Math.Round(total, 2).ToString();
        }
        void calcTotalPurshacing()
        {
            decimal t = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                t += Convert.ToDecimal(row[5].ToString());
            }
            txt_TotalPurshacing.Text = Math.Round(t, 2).ToString();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void Frm_AllProduct_Load(object sender, EventArgs e)
        {
        }
        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //reb7();
        }
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
                gridControl1.ShowRibbonPrintPreview();
            }
            else
            {
                MessageBox.Show("لا يوجد أصناف للطباعة");
            }
        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //gridControl1.DataSource = p.PrintAllProudects(Convert.ToInt32(Cmb_Store.SelectedValue));
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[9].Visible = false;
            //calcTotalSelling();
            //calcTotalPurshacing();
            //reb7();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_TotalSelling_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = p.Search_AllProudects(textBox1.Text);
                gridControl1.DataSource = dt;
                calcTotalSelling();
                calcTotalPurshacing();
                reb7();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
