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
    public partial class FormProudect : Form
    {
        DataTable dt = new DataTable();
        Proudect p = new Proudect();
        Category C = new Category();
        unit U = new unit();
        
        private static FormProudect farm;
        static void STATUESCllosed(object sender, FormClosedEventArgs e)
        {
            farm = null;
        }
    public static FormProudect getmain
        {
            get
            {
                if (farm == null)
                {
                    farm = new FormProudect();
                    farm.FormClosed += new FormClosedEventHandler(STATUESCllosed);
                }
                return farm; 
            }
        }     
        public FormProudect()
        {       
            InitializeComponent();
            if (farm == null)
            {
                farm = this;
            }
            dataGridViewPR.DataSource = p.selectProudect();
            btn_update.Enabled = false;
            btn_new.Hide();

            Cmb_Category.DataSource = C.Select_ComboCategory();
            Cmb_Category.DisplayMember = "Category_Name";
            Cmb_Category.ValueMember = "Category_Id";

            Cmb_LargeUnit.DataSource = U.Select_ComboUnit();
            Cmb_LargeUnit.DisplayMember = "Unit_Name";
            Cmb_LargeUnit.ValueMember = "Unit_Id";

            Cmb_SmallUnit.DataSource = U.Select_ComboUnit();
            Cmb_SmallUnit.DisplayMember = "Unit_Name";
            Cmb_SmallUnit.ValueMember = "Unit_Id";
            dataGridViewPR.Columns[5].Visible = false;
            dataGridViewPR.Columns[6].Visible = false;
            dataGridViewPR.Columns[10].Visible = false;
            dataGridViewPR.Columns[12].Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txt_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //txt_seelingPr.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txt_phrPri.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //txt_color.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //txt_size.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //txt_gender.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //txt_quantity.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //comboStock.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void FormProudect_Load(object sender, EventArgs e)
        {
        }
        public void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text == "")
                {
                    MessageBox.Show("يرجي التاكد من اسم المنتج");
                    txt_name.Focus();
                    return;
                }
                if (numbersmallUnit.Text == "")
                {
                    MessageBox.Show("يرجي كتابة عدد الوحدات الصغري داخل الوحدة الكبرى");
                    numbersmallUnit.Focus();
                    return;
                }
                if (PriceSmallUnit.Text == "")
                {
                    MessageBox.Show("يرجي كتابة سعر الوحدة الصغرى");
                    PriceSmallUnit.Focus();
                    return;
                }
                if (Cmb_SmallUnit.Text == "")
                {
                    MessageBox.Show("يرجي تحديد الوحدة الصغرى");
                    Cmb_SmallUnit.Focus();
                    return;
                }
                if (Cmb_LargeUnit.Text == "")
                {
                    MessageBox.Show("يرجي تحديد الوحدة الكبرى");
                    Cmb_LargeUnit.Focus();
                    return;
                }
                //else
                //{
                //    int x =Convert.ToInt32( p.Last_IdProd().Rows[0][0].ToString());
                //    p.addproudect( Convert.ToInt32(Cmb_Category.SelectedValue), txt_name.Text, decimal.Parse(txt_seeling.Text),
                //        decimal.Parse(txt_phr.Text),Convert.ToDecimal(txt_Minmum.Text), 0,Cmb_LargeUnit.Text, Convert.ToInt32(Cmb_LargeUnit.SelectedValue),
                //        Cmb_SmallUnit.Text,Convert.ToInt32(Cmb_SmallUnit.SelectedValue),Convert.ToInt32(numbersmallUnit.Text),Convert.ToDecimal(PriceSmallUnit.Text));
                //    MessageBox.Show("تم اضافه الصنف بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    dataGridViewPR.DataSource = p.selectProudect();
                //    clear();                    
                //}  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        internal void clear()
        {

            //txt_color.Text = "";
            //txt_gender.Text = "";
            //txt_quantity.Text = "";     
            //txt_barcode.Text = "";
            //txt_size.Clear();
            txt_name.Text = "";
            txt_seeling.Text = "0";
            txt_phr.Text = "0";
            txt_Minmum.Text = "0";
            numbersmallUnit.Text = "0";
            PriceSmallUnit.Text = "0";
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = p.searchForProduct(txt_search.Text);
                dataGridViewPR.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }      
        }

    
        

        private void btn_update_Click(object sender, EventArgs e)
        {
            try 
            { 
               if (txt_name.Text == "")
               {
                MessageBox.Show("يرجي التاكد من اسم المنتج");
                txt_name.Focus();
                return;
               }
                if (numbersmallUnit.Text == "")
                {
                    MessageBox.Show("يرجي كتابة عدد الوحدات الصغري داخل الوحدة الكبرى");
                    numbersmallUnit.Focus();
                    return;
                }
                if (PriceSmallUnit.Text == "")
                {
                    MessageBox.Show("يرجي كتابة سعر الوحدة الصغرى");
                    PriceSmallUnit.Focus();
                    return;
                }

                if (MessageBox.Show("هل تريد تعديل الصنف", "عمليه التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                //    p.Updateproudect(Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[0].Value),Convert.ToInt32(Cmb_Category.SelectedValue)
                //         , txt_name.Text,Convert.ToDecimal(txt_seeling.Text),Convert.ToDecimal(txt_phr.Text),Convert.ToDecimal(txt_Minmum.Text),
                //         Cmb_LargeUnit.Text, Convert.ToInt32(Cmb_LargeUnit.SelectedValue),Cmb_SmallUnit.Text,Convert.ToInt32(Cmb_SmallUnit.SelectedValue),
                //         Convert.ToInt32(numbersmallUnit.Text),Convert.ToDecimal(PriceSmallUnit.Text));
                    MessageBox.Show("تم تعديل الصنف بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                }
                else
                {
                    MessageBox.Show("تم الغاء عمليه التعديل", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dataGridViewPR.DataSource = p.selectProudect();
                p.Update_TotalProduct();
                clear();
                btn_add.Show();
                btn_new.Hide();
                btn_update.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridViewPR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewPR_DoubleClick(object sender, EventArgs e)
        {
            Cmb_Category.Text = dataGridViewPR.CurrentRow.Cells[1].Value.ToString();
            txt_name.Text = dataGridViewPR.CurrentRow.Cells[2].Value.ToString();
            txt_seeling.Text = dataGridViewPR.CurrentRow.Cells[3].Value.ToString();
            txt_phr.Text = dataGridViewPR.CurrentRow.Cells[4].Value.ToString();
            txt_Minmum.Text = dataGridViewPR.CurrentRow.Cells[7].Value.ToString();
            Cmb_LargeUnit.Text = dataGridViewPR.CurrentRow.Cells[9].Value.ToString();
            Cmb_SmallUnit.Text = dataGridViewPR.CurrentRow.Cells[11].Value.ToString();
            numbersmallUnit.Text = dataGridViewPR.CurrentRow.Cells[13].Value.ToString();
            PriceSmallUnit.Text = dataGridViewPR.CurrentRow.Cells[14].Value.ToString();
            btn_add.Hide();
            btn_update.Enabled = true;
            btn_new.Show();
        }
        private void btn_new_Click_1(object sender, EventArgs e)
        {
            clear();

            btn_new.Hide();
            btn_add.Show();
            btn_update.Enabled = false;
            
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
          
        }
         

        private void btn_add_Validated(object sender, EventArgs e)
        {
          
        }

        private void txt_name_Validated(object sender, EventArgs e)
        {
        }

        private void txt_seeling_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_seeling.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {

                e.Handled = true;

            }
        }

        private void txt_phr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_phr.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;

            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8 )
            {
                e.Handled = true;
            }
        }

        private void txt_phr_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_seeling_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_gender_Validated(object sender, EventArgs e)
        {
        }

        private void btn_add_Validating(object sender, CancelEventArgs e)
        {
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //Frm_printBarcode fpc = new Frm_printBarcode();
            //Frm_printBarcode.getmain.txt_name.Text = txt_name.Text;
            //Frm_printBarcode.getmain.txt_price.Text = txt_seeling.Text;
            //Frm_printBarcode.getmain.txt_barcode.Text = txt_barcode.Text;
            //fpc.ShowDialog();
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_RandomBarcode_Click(object sender, EventArgs e)
        {
     
            //DataTable dt3 = new DataTable();
            //dt3.Clear();
            //dt3 = p.selectLastBarcode();

            //if (dt3.Rows.Count <= 0)
            //{
            //    txt_barcode.Text = "123456";

            //    p.add_randomBarcode(Convert.ToInt32("123456"));
            //}
            //else
            //{
            //    txt_barcode.Text = (Convert.ToInt32(dt3.Rows[0][0]) + 1).ToString();

            //p.Update_Barcode(Convert.ToInt32(dt3.Rows[0][0]) + 1);

            //}

        }

        private void Btn_PrintPreview_Click(object sender, EventArgs e)
        {

            //if (txt_name.Text == "" || txt_barcode.Text == "" || txt_seeling.Text == "")
            //{
            //    MessageBox.Show("يرجى التاكد من البيانات");
            //    return;
            //}
            //DataSet1 ds = new DataSet1();
            //ds.Clear();
            //Rpt.CrystalReport2 cr = new Rpt.CrystalReport2();
            //ds.Tables[0].Rows.Add(txt_name.Text, "*" + txt_barcode.Text.Trim() + "*", txt_barcode.Text, txt_seeling.Text);
            //cr.SetDataSource(ds);
            //Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
            //frm.crystalReportViewer1.ReportSource = cr;
            //frm.crystalReportViewer1.Refresh();
            //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
            //cr.PrintToPrinter(Convert.ToInt32(txt_quantity.Text), true, 0, 0);
            ////frm.ShowDialog();
            //cr.Close();
        }

        private void Txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&e.KeyChar!= 8)
            {
                e.Handled = true;
            }
        }

        private void Txt_phr_MouseClick(object sender, MouseEventArgs e)
        {
            txt_phr.SelectAll();
        }

        private void Txt_seeling_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void Txt_quantity_MouseClick(object sender, MouseEventArgs e)
        {
            //txt_quantity.SelectAll();
        }

        private void txt_Minmum_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void txt_Minmum_Leave(object sender, EventArgs e)
        {
            if (txt_Minmum.Text=="")
            {
                txt_Minmum.Text = "0";
            }        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_Category cat = new Frm_Category();
            try
            {
                cat.ShowDialog();
                Cmb_Category.DataSource = C.Select_ComboCategory();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                cat.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Unit Un = new Frm_Unit();
            try
            {
                Un.ShowDialog();
                Cmb_LargeUnit.DataSource = U.Select_ComboUnit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Un.Dispose();
            }
  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Unit Un = new Frm_Unit();
            try
            {
                Un.ShowDialog();
                Cmb_LargeUnit.DataSource = U.Select_ComboUnit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Un.Dispose();
            }
        }

        private void numbersmallUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void PriceSmallUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && PriceSmallUnit.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;

            }
        }

        private void numbersmallUnit_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void numbersmallUnit_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txt_Minmum_Move(object sender, EventArgs e)
        {
            if (txt_Minmum.Text == "")
            {
                txt_Minmum.Text = "0";
            }
        }

        private void txt_Minmum_Click(object sender, EventArgs e)
        {
            if (txt_Minmum.Text == "0")
            {
                txt_Minmum.Text = "";
            }
        }

        private void txt_Minmum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_phr_Click(object sender, EventArgs e)
        {
            if (txt_phr.Text == "0")
            {
                txt_phr.Text = "";
            }
        }

        private void numbersmallUnit_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PriceSmallUnit_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void PriceSmallUnit_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void txt_phr_Leave(object sender, EventArgs e)
        {
            if (txt_phr.Text == "")
            {
                txt_phr.Text = "0";
            }
        }

        private void txt_seeling_Click(object sender, EventArgs e)
        {
            if (txt_seeling.Text == "0")
            {
                txt_seeling.Text = "";
            }
        }

        private void numbersmallUnit_Click(object sender, EventArgs e)
        {
            if (numbersmallUnit.Text == "0")
            {
                numbersmallUnit.Text = "";
            }
        }

        private void numbersmallUnit_Leave(object sender, EventArgs e)
        {
            if (numbersmallUnit.Text == "")
            {
                numbersmallUnit.Text = "0";
            }
        }

        private void PriceSmallUnit_Click(object sender, EventArgs e)
        {
            if (PriceSmallUnit.Text == "0")
            {
                PriceSmallUnit.Text = "";
            }
        }

        private void PriceSmallUnit_Leave(object sender, EventArgs e)
        {
            if (PriceSmallUnit.Text == "")
            {
                PriceSmallUnit.Text = "0";
            }
        }

        private void numbersmallUnit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numbersmallUnit.Text == "" || numbersmallUnit.Text == "0")
                {
                    PriceSmallUnit.Text = txt_seeling.Text;
                }
                else if (txt_seeling.Text != "" && numbersmallUnit.Text != "")
                {
                    PriceSmallUnit.Text = (Convert.ToDecimal(txt_seeling.Text) / Convert.ToInt32(numbersmallUnit.Text)).ToString();
                }
            }
            catch (Exception )
            {

                MessageBox.Show("");
            }
        }
    }

}

    




