using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using clothesStore.Bl;
namespace clothesStore.PL
{
    public partial class Frm_TransFairProduct : DevExpress.XtraEditors.XtraForm
    {
        Proudect p = new Proudect();
        Store Store = new Store();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt51 = new DataTable();

        void ComboProduct()
        {
            //Cmb_product.DataSource = p.Select_ProductFormStoreForSale(Convert.ToInt32(Cmb_StoreFrom.SelectedValue));
            Cmb_product.DisplayMember = "Name_Prod";
            Cmb_product.ValueMember = "ID_Product";
        }
        void ComboFromStore()
        {
            Cmb_StoreFrom.DataSource = Store.Select_ComboStore();
            Cmb_StoreFrom.DisplayMember = "Store_Name";
            Cmb_StoreFrom.ValueMember = "Store_Id";
        }
        void CombToStore()
        {
            Cmb_ToStore.DataSource = Store.Select_ComboStore();
            Cmb_ToStore.DisplayMember = "Store_Name";
            Cmb_ToStore.ValueMember = "Store_Id";
        }
        void SelectdataTable()
        {
            dt.Columns.Add("رقم الصنف");//0
            dt.Columns.Add("اسم الصنف");//1
            dt.Columns.Add("الوحدة");//2
            dt.Columns.Add("الكميه "); //3 
            dt.Columns.Add("سعر الشراء "); //4
            DgvSale.DataSource = dt;
        }
        public Frm_TransFairProduct()
        {
            InitializeComponent();
            SelectdataTable();
            ComboFromStore();
            CombToStore();
            ComboProduct();
            //txt_num.Text = p.Select_LastIdTranfair().Rows[0][0].ToString();
            txt_sales.Text = Program.salesman;
            Btn_Print.Hide();
            label5.Hide();
            txt_num.Hide();
        }
        private void txt_note_TextChanged(object sender, EventArgs e)
        {
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt51.Clear();
                //dt51 = p.selectListProudect(Convert.ToInt32(Cmb_StoreFrom.SelectedValue), Convert.ToInt32(Cmb_product.SelectedValue));
                if (Cmb_product.Text != "" && dt51.Rows.Count > 0)
                {
                    for (int i = 0; i < DgvSale.Rows.Count; i++)
                    {
                        if (DgvSale.Rows[i].Cells[0].Value.ToString() == dt51.Rows[0][0].ToString())
                        {
                            if (Convert.ToInt32(DgvSale.Rows[i].Cells[3].Value) >= Convert.ToInt32(dt51.Rows[0][5]))
                            {
                                MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                int x = 1;
                                Console.Beep();
                                DgvSale.Rows[i].Cells[3].Value = Convert.ToInt32(DgvSale.Rows[i].Cells[3].Value) + x;
                                return;
                            }
                        }
                    }
                    DataRow r = dt.NewRow();
                    r[0] = dt51.Rows[0][0];
                    r[1] = dt51.Rows[0][1];
                    r[2] = dt51.Rows[0][3];
                    r[3] = 1.00;
                    r[4] = dt51.Rows[0][7];
                    dt.Rows.Add(r);
                    Console.Beep();
                    DgvSale.DataSource = dt;                 
                    DataTable dt5 = new DataTable();
                    //dt5.Clear();
                    ////dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][0]),Convert.ToInt32(Cmb_StoreFrom.SelectedValue));
                    //if (dt5.Rows.Count > 0)
                    //{
                    //    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}                   
                    lblItemsCount.Text = DgvSale.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Cmb_product_Leave(object sender, EventArgs e)
        {
            if (Cmb_product.Text != "")
            {
                dt2.Clear();
                dt2 = p.Validate_ProductFormStoreForSale(Convert.ToInt32(Cmb_product.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم الصنف الذى قمت باادخالة غير موجود فى قائمة الاصناف ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Cmb_product.SelectAll();
                    Cmb_product.Focus();
                    return;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSale.Rows.Count <= 0) { MessageBox.Show("لا بد من اختيار صنف واحد على الاقل "); return; }
                if (Cmb_StoreFrom.Text == "") { MessageBox.Show("لابد من اختيار المخزن المحول منه "); return; }
                if (Cmb_ToStore.Text == "") { MessageBox.Show("لابد من اختيار المخزن المحول إلية "); return; }
                if (DgvSale.Rows.Count > 0 )
                {
                    btn_save.Enabled = false;
                    DgvSale.Enabled = false;
                    p.Add_TranfairProductInformation(Convert.ToInt32(Cmb_StoreFrom.SelectedValue),
                                   Cmb_StoreFrom.Text,Convert.ToInt32(Cmb_ToStore.SelectedValue),Cmb_ToStore.Text,txt_sales.Text,
                                   dateTimePicker1.Value,txt_note.Text);
                    txt_num.Text = p.Select_LastIdTranfair().Rows[0][0].ToString();

                    for (int i = 0; i < DgvSale.Rows.Count; i++)
                    {
                        p.Add_TRansfairProductDetails(Convert.ToInt32(txt_num.Text),Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),
                                        DgvSale.Rows[i].Cells[2].Value.ToString(),Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value));
                      
                        dt6.Clear();
                        dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value), (DgvSale.Rows[i].Cells[2].Value.ToString()));
                        decimal x = Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value) / Convert.ToDecimal(dt6.Rows[0][1]);

                        //p.Update_ProductQuantityDecrease(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),
                        //    Convert.ToInt32(Cmb_StoreFrom.SelectedValue), x);

                        //dt2.Clear();
                        //dt2 = Store.Select_ProductStore(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),Convert.ToInt32(Cmb_ToStore.SelectedValue));
                        //if (dt2.Rows.Count>0)
                        //{
                        //    p.Update_ProductQuantityIncrease(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),
                        //    Convert.ToInt32(Cmb_ToStore.SelectedValue), x);
                        //}
                        //else
                        //{
                        //    Store.Add_StoreProduct(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value), Convert.ToInt32(Cmb_ToStore.SelectedValue)
                        //                           ,x, Convert.ToDecimal(DgvSale.Rows[i].Cells[4].Value));
                        //    Store.Update_StoreProduct(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),x);
                        //}
                    }
                   
                    MessageBox.Show("تم اضافه الفاتوره بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dt.Clear();
                    DgvSale.Enabled = true;
                    btn_save.Enabled = true;
                    Btn_Print.Enabled = true;
                }
                else
                {
                    MessageBox.Show("من فضلك قم بااختيار صنف واحد علي الاقل  ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }


        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            dt.Clear();
            DgvSale.Enabled = true;
            btn_save.Enabled = true;
        }
        void Update_QtyUnit()
        {
            Frm_EditQuantity Frm = new Frm_EditQuantity();

            if (DgvSale.Rows.Count > 0 && DgvSale.SelectedRows.Count > 0)
            {
                Frm.cmb_Unit.DataSource = p.Select_UnitProduct(Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value));
                Frm.cmb_Unit.DisplayMember = "Unit_Name";
                Frm.cmb_Unit.ValueMember = "Id_Unit";
                Frm.textBox1.Text = DgvSale.CurrentRow.Cells[0].Value.ToString();
                Frm.Txt_numStore.Text = (Cmb_StoreFrom.SelectedValue).ToString();
                Frm.ShowDialog();

            }
            if (Frm.Txt_Quantity.Text != "0" )
            {

                DgvSale.CurrentRow.Cells[2].Value = Frm.cmb_Unit.Text;
                DgvSale.CurrentRow.Cells[3].Value = Frm.Txt_Quantity.Text;
 
                DataTable dt3 = new DataTable();
                dt3.Clear();
                //dt3 = p.SelectQuantityMinmun(Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value),Convert.ToInt32(Cmb_StoreFrom.SelectedValue));
                if (dt3.Rows.Count > 0)
                {
                    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        
                Frm.Txt_Quantity.Clear();
             
            }
        }

        private void DgvSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Update_QtyUnit();
            }
        }

        private void Cmb_StoreFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt.Clear();
            ComboProduct();
        }

        private void DgvSale_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblItemsCount.Text = DgvSale.Rows.Count.ToString();
        }
    }
}