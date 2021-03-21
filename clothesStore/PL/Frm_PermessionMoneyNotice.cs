using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clothesStore;
using clothesStore.Bl;

namespace clothesStore.PL
{
    public partial class Frm_PermessionMoneyNotice : Form
    {
        Customer Cm = new Customer();
        Order o = new Order();
        Stock s = new Stock();
        DataTable dt = new DataTable();
        public Frm_PermessionMoneyNotice()
        {
            InitializeComponent();
            Function();
        }
        void Function()
        {
            try
            {

                Txt_SalesMAn.Text = Program.salesman;
                ComboCustomer();
                ComboStock();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void ComboCustomer()
        {
            cmb_client.DataSource = o.SelectCustNameSarfPay();
            cmb_client.DisplayMember = "Name";
            cmb_client.ValueMember = "ID_Cust";
            cmb_client.SelectedIndex = -1;
        }
        void ComboStock()
        {
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
        }
        private void Frm_PermessionMoneyNotice_Load(object sender, EventArgs e)
        {

        }

        private void Txt_Money_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '.' && Txt_Money.Text.ToString().IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
            //else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar((System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            //{
            //    e.Handled = true;
            //}
        }

        private void Txt_Money_MouseMove(object sender, MouseEventArgs e)
        {
            //if (Txt_Money.Text == "")
            //{
            //    Txt_Money.Text = "0";
            //}
        }

        private void Txt_Money_Click(object sender, EventArgs e)
        {
            //Txt_Money.SelectAll();
            
        }

        private void cmb_client_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt =Cm.Select_CustomerBalance(Convert.ToInt32(cmb_client.SelectedValue));
                    if (dt.Rows.Count>0 && (Convert.ToDecimal(dt.Rows[0][1]) <0))
                    {
                        Txt_Balance.Text = (Convert.ToDecimal(dt.Rows[0][1]) * -1).ToString();
                    }
                else
                {
                    MessageBox.Show("لا يوجد مبلغ مستحق لهذا العميل ");
                    return;
                }
                  
                
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
                MessageBox.Show(EX.StackTrace);
            }
        }

        private void cmb_client_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                dt.Clear();
                dt = Cm.Select_CustomerBalance(Convert.ToInt32(cmb_client.SelectedValue));
                if (dt.Rows.Count > 0 && (Convert.ToDecimal(dt.Rows[0][1]) < 0))
                {
                    Txt_Balance.Text = (Convert.ToDecimal(dt.Rows[0][1]) * -1).ToString();
                }
                else
                {
                    MessageBox.Show("لا يوجد مبلغ مستحق لهذا العميل ");
                    return;
                }


            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
                MessageBox.Show(EX.StackTrace);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                //if (Convert.ToDecimal(Txt_Money.Text) > Convert.ToDecimal(Txt_Balance.Text))
                //{
                //    MessageBox.Show("لا يسمح بصرف مبلغ أكبر من المبلغ المستحق لعميل");
                //    return;
                //}
               
                if (cmb_client.Text=="")
                {
                    MessageBox.Show("لا بد من تحديد إسم العميل المراد الصرف له ");
                    return;
                }
                if (Txt_Balance.Text == "" || Txt_Balance.Text == "0")
                {
                    MessageBox.Show("لا بد من وجود مبلغ مستحق للعميل للصرف له");
                    return;
                }
                if (MessageBox.Show("هريد تأكيد صرف المبلغ المراد تحديده ","تأكيد صرف مبلغ ",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                    dt.Clear();
                    dt = s.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(Txt_Balance.Text) > Convert.ToDecimal(dt.Rows[0][0]))
                        {
                            MessageBox.Show("رصيد الخزنة الحالى غير كافى لصرف هذا المبلغ للعميل");
                            return;

                        }
                    }

                    if (Convert.ToDecimal(Txt_Balance.Text) > 0)
                    {
                        s.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(Txt_Balance.Text),
                            dateTimePicker1.Value,
                            Txt_SalesMAn.Text, "صرف مبلغ مستحق للعميل" +" "+ cmb_client.Text, "صرف مبلغ مستحق للعميل" + " " + cmb_client.Text);
                    }
                    dt.Clear();
                    dt = Cm.Select_CustomerBalance(Convert.ToInt32(cmb_client.SelectedValue));
                    decimal hrl = Convert.ToDecimal(dt.Rows[0][1]) * -1;

                    //decimal mno5 = Convert.ToDecimal(Txt_PayLast.Text) - Convert.ToDecimal(Txt_LastPayOut.Text);
                    decimal mno4 = Convert.ToDecimal(dt.Rows[0][1]) + Convert.ToDecimal(Txt_Balance.Text);
                    Cm.Update_CustomerTotalMoney(Convert.ToInt32(cmb_client.SelectedValue), mno4);
                    Cm.Add_CustomerStatmentAccount(Convert.ToInt32(cmb_client.SelectedValue), 0,
                    Convert.ToDecimal(Txt_Balance.Text),
                   " إذن صرف مبلغ   " + " (" + (Txt_Balance.Text) + " )", dateTimePicker1.Value, mno4, Txt_SalesMAn.Text);
                        MessageBox.Show("تم تأكيد صرف المبلغ المحدد للعميل");
                        cmb_client.SelectedIndex = -1;
                        Txt_Balance.Text = "0";
                        

                    }
                    else
                    {
                        MessageBox.Show("تم إلغاء صرف المبلغ المراد صرفه يرجى التأكد من العملية و إعادة المحاولة");
                        return;
                    }

                      
                

            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
                MessageBox.Show(EX.StackTrace);
            }
        }

        private void txt_reasonAddition_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void cmb_client_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmb_client.Text != "")
                {
                    dt.Clear();
                    dt = Cm.VildateCustomer(Convert.ToInt32(cmb_client.SelectedValue));
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("اسم العميل الذى قمت بإدخالة غير مسجل من قبل  ", "تنبيه", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        cmb_client.SelectAll();
                        cmb_client.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
               
            //    if (cmb_client.SelectedIndex != -1)
            //    {
            //        dt = c.selectOneClientRent(Convert.ToInt32((DataRowView)cmb_client.SelectedValue));
            //        if (dt.Rows.Count > 0)
            //        {
            //            Txt_Balance.Text = (Convert.ToDecimal(dt.Rows[0][2]) * -1).ToString();
            //        }

            //    }

            //}
            //catch (Exception EX)
            //{

            //    MessageBox.Show(EX.Message);
            //    MessageBox.Show(EX.StackTrace);
            //}
        }

        private void cmb_client_SelectedValueChanged(object sender, EventArgs e)
        {
 
        }

        private void cmb_client_Click(object sender, EventArgs e)
        {
       
        }

        private void cmb_client_MouseMove(object sender, MouseEventArgs e)
        {
    
        }

        private void Cmb_Branch_SelectionChangeCommitted(object sender, EventArgs e)
        {
        //    try
        //    {
        //        cmb_Stock.DataSource = s.SelectStockBranch(Convert.ToInt32(Cmb_Branch.SelectedValue));
        //        cmb_Stock.DisplayMember = "Name_Stock";
        //        cmb_Stock.ValueMember = "ID_Stock";
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        }
    }
}
