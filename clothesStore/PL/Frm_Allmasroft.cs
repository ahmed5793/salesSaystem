
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
    public partial class Frm_Allmasroft : Form
    {
        Masrofat m = new Masrofat(); 
        DataTable dt = new DataTable();

        public Frm_Allmasroft()
        {
            InitializeComponent();
            Rdb_AllMasrofat.Checked = true;
            gridControl1.DataSource = m.Select_masrofat();
            //Cmb_MasrofatCategory.DataSource = m.Select_MasrofatCategory();
            //Cmb_MasrofatCategory.DisplayMember = "Mastof_Name";
            //Cmb_MasrofatCategory.ValueMember = "Id_MAsrof";
            Cmb_MasrofatCategory.Enabled = false;
    

            calcTotal();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();
        }
        void calcTotal()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount ; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(r[2].ToString());
            }
            textBox1.Text = Math.Round(total, 2).ToString();
        }
        private void Frm_Allmasroft_Load(object sender, EventArgs e)
        {

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_AllMasrofat_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_AllMasrofat.Checked==true)
            {
                Cmb_MasrofatCategory.Enabled = false;
                Cmb_MasrofatCategory.DataSource = null;
                Cmb_MasrofatCategory.Enabled = false;
                gridControl1.DataSource = m.Select_masrofat();
                calcTotal();

            }
            else
            {
             
                Cmb_MasrofatCategory.Enabled = true;
                Cmb_MasrofatCategory.DataSource = m.Select_MasrofatCategory();
                Cmb_MasrofatCategory.DisplayMember = "Mastof_Name";
                Cmb_MasrofatCategory.ValueMember = "Id_MAsrof";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rdb_AllMasrofat.Checked==true)
                {
                    dt.Clear();
                    dt = m.Searech_masrofatDate(dateTimePicker1.Value, dateTimePicker2.Value);
                    if (dt.Rows.Count>0)
                    {
                        gridControl1.DataSource = dt;
                        calcTotal();
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد مصروفات فى هذه الفترة");
                    }
                 
                }
                else if (Rdb_oneMasrof.Checked==true)
                {
                    dt.Clear();
                    dt = m.Searech_onemasrofatDate(Convert.ToInt32(Cmb_MasrofatCategory.SelectedValue),dateTimePicker1.Value, dateTimePicker2.Value);
                    if (dt.Rows.Count>0)
                    {
                        gridControl1.DataSource = dt;
                        calcTotal();
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد مصروفات فى هذه الفترة");
                    }
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Cmb_MasrofatCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Rdb_oneMasrof.Checked==true)
                {
                    gridControl1.DataSource = m.Select_Onemasrofat(Convert.ToInt32(Cmb_MasrofatCategory.SelectedValue));
                    calcTotal();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Rdb_oneMasrof_CheckedChanged(object sender, EventArgs e)
        {
            Cmb_MasrofatCategory.DataSource = m.Select_MasrofatCategory();
            Cmb_MasrofatCategory.DisplayMember = "Mastof_Name";
            Cmb_MasrofatCategory.ValueMember = "Id_MAsrof";
        }
    }
}
