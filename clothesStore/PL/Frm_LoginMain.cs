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
    public partial class Frm_LoginMain : DevExpress.XtraEditors.XtraForm
    {
        Login l = new Login();
        public Frm_LoginMain()
        {
            InitializeComponent();
        }

        private void txt_User_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_User.Text == "USER NAME")
            {
                txt_User.Text = "";


            }
            else if (txt_User.Text == "")
            {
                txt_User.Text = "USER NAME";
            }
        }

        private void txt_User_Leave(object sender, EventArgs e)
        {
            if (txt_User.Text == "")
            {

                txt_User.Text = "USER NAME";
            }
        }

        private void txt_Pass_MouseMove(object sender, MouseEventArgs e)
        {
            if (txt_Pass.Text != "PASSWORD")
            {
                checkBox1.Checked = false;
                txt_Pass.UseSystemPasswordChar = true;
            }
        }

        private void txt_Pass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Pass.Text == "PASSWORD")
            {

                txt_Pass.Text = "";
                checkBox1.Checked = false;
                txt_Pass.UseSystemPasswordChar = true;


            }
            else if (txt_Pass.Text == "")
            {
                txt_Pass.Text = "PASSWORD";

            }
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_Pass.Text != "PASSWORD")
            {


                if (checkBox1.Checked == true)
                {
                    txt_Pass.UseSystemPasswordChar = false;
                }
                else
                {
                    txt_Pass.UseSystemPasswordChar = true;
                }
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void txt_Pass_Leave(object sender, EventArgs e)
        {

            if (txt_Pass.Text == "")
            {


                checkBox1.Checked = true;
                txt_Pass.Text = "PASSWORD";





            }
        }

        private void txt_Pass_KeyDown(object sender, KeyEventArgs e)
        {

            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {



            //        if (Properties.Settings.Default.ProudectKey == "NO")
            //        {
            //            frm_SerielNumber FS = new frm_SerielNumber();
            //            FS.ShowDialog();
            //        }
            //        else
            //        {





            //            if (txt_User.Text == "")
            //            {
            //                MessageBox.Show("PLEASE INSERT USER NAME");
            //                return;
            //            }
            //            if (txt_Pass.Text == "")
            //            {
            //                MessageBox.Show("PLEASE INSERT PASSWORD");
            //                return;
            //            }

            //            else
            //            {
            //                dt.Clear();
            //                dt = U.Logins(txt_User.Text, txt_Pass.Text);

            //                if (dt.Rows.Count > 0)
            //                {
            //                    //DataTable dt50 = new DataTable();
            //                    //DataTable dt5 = new DataTable();


            //                    //    dt50.Clear();
            //                    //    dt50 = U.SelectCheckUserName(txt_User.Text);
            //                    //    if (dt50.Rows.Count>0)
            //                    //    {
            //                    //        MessageBox.Show("عفوا هذا الاكونت مفتوح من جهاز اخر يرجي غلق الاكونت ثم اعد فتحه مرة اخرى");
            //                    //        return;
            //                    //    }


            //                    backgroundWorker1.RunWorkerAsync();



            //                    Program.salesman = dt.Rows[0][1].ToString();
            //                    Console.Beep();
            //                    this.Hide();
            //                    //dt5 = U.SelectCheckUserNameOffline(txt_User.Text);
            //                    //if (dt5.Rows.Count > 0)
            //                    //{
            //                    //    dt50.Clear();
            //                    //    dt50 = U.SelectCheckUserName(txt_User.Text);
            //                    //    if (dt50.Rows.Count == 0)
            //                    //    {
            //                    //        U.UpdateCheckUserName(txt_User.Text, "Online", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")), Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")));

            //                    //}

            //                    //}


            //                    //else
            //                    //{

            //                    //    U.AddCheckUserName(txt_User.Text, "Online", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")),
            //                    //     Convert.ToDateTime(DateTime.Now.ToString()));
            //                    //}
            //                    fm.ShowDialog();
            //                    Users u = new Users();
            //                    DataTable dt10 = new DataTable();
            //                    dt10.Clear();

            //                    dt10 = u.SelectAllCheckUserName();












            //                }
            //                else
            //                {
            //                    MessageBox.Show("Incorrect password or username");
            //                }

            //            }




            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);

            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        form_main fm = new form_main();
        Frm_Main frm_main = new Frm_Main();
        DataTable DT88 = new DataTable();
        private void bunifuThinButton2_Click(object sender, EventArgs e)
        {

            try
            {


                if (Properties.Settings.Default.ProudectKey == "NO")
                {
                    frm_SerielNumber FS = new frm_SerielNumber();
                    FS.ShowDialog();
                }
                else
                {





                    if (txt_User.Text == "")
                    {
                        MessageBox.Show("PLEASE INSERT USER NAME");
                        return;
                    }
                    if (txt_Pass.Text == "")
                    {
                        MessageBox.Show("PLEASE INSERT PASSWORD");
                        return;
                    }

                    else
                    {

                      
                        DT88.Clear();
                        DT88 = l.st_login(txt_User.Text, txt_Pass.Text);


                         

                        if (DT88.Rows.Count > 0)

                        {

                            backgroundWorker1.RunWorkerAsync();


                            Program.salesman = DT88.Rows[0][2].ToString();

                               
                                    Console.Beep();
                               
                                    this.Hide();
                                   
                            
                            frm_main.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Incorrect password or username");
                        }

                    }




                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        Permession p = new Permession();
        
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            //try
            //{
            //    dt2.Clear();
                dt2 = p.SelectUserProduct(txt_User.Text);
                if (dt2.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt2.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_addProduct.Enabled = false;
                        Frm_Main.getmain.tileI_AddItem.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt2.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_addProduct.Enabled = true;
                        Frm_Main.getmain.tileI_AddItem.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt2.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.Bnt_Minimum.Enabled = false;
                        Frm_Main.getmain.tileI_MineItem.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt2.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.Bnt_Minimum.Enabled = true;
                        Frm_Main.getmain.tileI_MineItem.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt2.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_BalanceAdjustment.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt2.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_BalanceAdjustment.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt2.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_RepAdjustmentbalance.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt2.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.Btn_RepAdjustmentbalance.Enabled = true;
                    }
                    /////////
                    if (Convert.ToInt32(dt2.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReportAllProduct.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt2.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.Btn_ReportAllProduct.Enabled = true;

                    }

                    if (Convert.ToInt32(dt2.Rows[0][6]) == 0)
                    {
                        Frm_Main.getmain.btn_HarkaItems.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt2.Rows[0][6]) == 1)
                    {
                        Frm_Main.getmain.btn_HarkaItems.Enabled = true;

                    }
                }
                // -------------------Part (2) -------------------------
                ///////



                dt3.Clear();
                dt3 = p.SelectUserClient(txt_User.Text);
                if (dt3.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt3.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddCust.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt3.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddCust.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt3.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.BtnAdd_CustomerMoney.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt3.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.BtnAdd_CustomerMoney.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt3.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_PayCustomer.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt3.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_PayCustomer.Enabled = true;
                    }

                    ///////

                    /////////
                    if (Convert.ToInt32(dt3.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_DebitCustomer.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt3.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.Btn_DebitCustomer.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt3.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.Btn_CustomerStatment.Enabled = false;
                        Frm_Main.getmain.tileI_AccountCust.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt3.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.Btn_CustomerStatment.Enabled = true;
                        Frm_Main.getmain.tileI_AccountCust.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt3.Rows[0][6]) == 0)
                    {
                        Frm_Main.getmain.Btn_SarfMabl5ll3mel.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt3.Rows[0][6]) == 1)
                    {
                        Frm_Main.getmain.Btn_SarfMabl5ll3mel.Enabled = true;
                    }
                //////
                ///
                if (Convert.ToInt32(dt3.Rows[0][7]) == 0)
                {
                    Frm_Main.getmain.Btn_AllCustomer.Enabled = false;
                }
                else if (Convert.ToInt32(dt3.Rows[0][7]) == 1)
                {
                    Frm_Main.getmain.Btn_AllCustomer.Enabled = true;
                }

            }

                //---------------------------PART (3)-------------------------------


                dt4.Clear();
                dt4 = p.SelectUserSuppliers(txt_User.Text);
                if (dt4.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt4.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddSuppliers.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt4.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddSuppliers.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt4.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.btn_reportDataSupp.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt4.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.btn_reportDataSupp.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt4.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddSupplierMoney.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt4.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddSupplierMoney.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt4.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_PaySuppliers.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt4.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.Btn_PaySuppliers.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt4.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.Btn_SupplierStatment.Enabled = false;
                        Frm_Main.getmain.tileI_AccountSupp.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt4.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.Btn_SupplierStatment.Enabled = true;
                        Frm_Main.getmain.tileI_AccountSupp.Enabled = true;
                    }
                    /////
                    if (Convert.ToInt32(dt4.Rows[0][6]) == 0)
                    {
                        Frm_Main.getmain.Btn_DebitSuppliers.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt4.Rows[0][6]) == 1)
                    {
                        Frm_Main.getmain.Btn_DebitSuppliers.Enabled = true;
                    }
                }
                //------------------------Part (4)----------------------
                dt5.Clear();
                dt5 = p.selectUserOrder(txt_User.Text);
                if (dt5.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt5.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_SalesInnvoice.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt5.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_SalesInnvoice.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt5.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReturnSales.Enabled = false;
                        Frm_Main.getmain.tileI_ReturnOrder.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt5.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.Btn_ReturnSales.Enabled = true;
                        Frm_Main.getmain.tileI_ReturnOrder.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt5.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_AllOrder.Enabled = false;
                        Frm_Main.getmain.tileI_ManagmentOrder.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt5.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_AllOrder.Enabled = true;
                        Frm_Main.getmain.tileI_ManagmentOrder.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt5.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReportOrderReturn.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt5.Rows[0][4]) == 1)
                    {

                        Frm_Main.getmain.Btn_ReportOrderReturn.Enabled = true;
                    }
                    /////////
                    if (Convert.ToInt32(dt5.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.Btn_SalesArba7.Enabled = false;
                        Frm_Main.getmain.tileI_Reb7.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt5.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.Btn_SalesArba7.Enabled = true;
                        Frm_Main.getmain.tileI_Reb7.Enabled = true;
                    }

                }


                ///--------------------------Part (5)-------------------------------
                dt6.Clear();
                dt6 = p.selectUserPurshise(txt_User.Text);
                if (dt6.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt6.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_PurshasingInnvoice.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt6.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_PurshasingInnvoice.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt6.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.Btn_PurshasingReturn.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt6.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.Btn_PurshasingReturn.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt6.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_PurshasingMangement.Enabled = false;
                        Frm_Main.getmain.tileI_ManagmentSupplier.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt6.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_PurshasingMangement.Enabled = true;
                        Frm_Main.getmain.tileI_ManagmentSupplier.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt6.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReportpurshasingReturn.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt6.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.Btn_ReportpurshasingReturn.Enabled = true;
                    }
                }
                ////------------------------part (6)-------------------------
                ///
                dt7.Clear();
                dt7 = p.selectUserStock(txt_User.Text);
                if (dt7.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt7.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_Masrofat.Enabled = false;
                        Frm_Main.getmain.tilel_Masrof.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt7.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_Masrofat.Enabled = true;
                        Frm_Main.getmain.tilel_Masrof.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt7.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.Btn_MAsrofatReport.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.Btn_MAsrofatReport.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt7.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddNewStock.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddNewStock.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt7.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddStockMoney.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddStockMoney.Enabled = true;
                    }


                    ///////
                    if (Convert.ToInt32(dt7.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.Btn_AddStockPull.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.Btn_AddStockPull.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt7.Rows[0][6]) == 0)
                    {
                        Frm_Main.getmain.Btn_TransfairStock.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][6]) == 1)
                    {
                        Frm_Main.getmain.Btn_TransfairStock.Enabled = true;
                    }


                    if (Convert.ToInt32(dt7.Rows[0][7]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReportInsertStock.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][7]) == 1)
                    {
                        Frm_Main.getmain.Btn_ReportInsertStock.Enabled = true;
                    }


                    if (Convert.ToInt32(dt7.Rows[0][8]) == 0)
                    {
                        Frm_Main.getmain.Btn_ReportPullStock.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt7.Rows[0][8]) == 1)
                    {
                        Frm_Main.getmain.Btn_ReportPullStock.Enabled = true;
                    }
                }
                ///----------------------------part (7)---------------------------

                dt8.Clear();
                dt8 = p.selectUserFile(txt_User.Text);
                if (dt8.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(dt8.Rows[0][1]) == 0)
                    {
                        Frm_Main.getmain.Btn_Backup.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt8.Rows[0][1]) == 1)
                    {
                        Frm_Main.getmain.Btn_Backup.Enabled = true;
                    }
                    ///////
                    if (Convert.ToInt32(dt8.Rows[0][2]) == 0)
                    {
                        Frm_Main.getmain.Btn_Restore.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt8.Rows[0][2]) == 1)
                    {
                        Frm_Main.getmain.Btn_Restore.Enabled = true;
                    }
                    ////////
                    if (Convert.ToInt32(dt8.Rows[0][3]) == 0)
                    {
                        Frm_Main.getmain.btn_Setting.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt8.Rows[0][3]) == 1)
                    {
                        Frm_Main.getmain.btn_Setting.Enabled = true;
                    }

                    ///////
                    if (Convert.ToInt32(dt8.Rows[0][4]) == 0)
                    {
                        Frm_Main.getmain.btn_managmentUser.Enabled = false;
                    }
                    else if (Convert.ToInt32(dt8.Rows[0][4]) == 1)
                    {
                        Frm_Main.getmain.btn_managmentUser.Enabled = true;
                    }

                    if (Convert.ToInt32(dt8.Rows[0][5]) == 0)
                    {
                        Frm_Main.getmain.btn_Permission.Enabled = false;
                        Frm_Main.getmain.tileI_UserManagment.Enabled = false;

                    }
                    else if (Convert.ToInt32(dt8.Rows[0][5]) == 1)
                    {
                        Frm_Main.getmain.btn_Permission.Enabled = true;
                        Frm_Main.getmain.tileI_UserManagment.Enabled = true;
                    }
                }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Frm_LoginMain_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            if (txt_Pass.Text != "PASSWORD")
            {
                if (checkBox1.Checked == true)
                {
                    checkBox1.Checked = false;
                    txt_Pass.UseSystemPasswordChar = true;
                }


            }
        }
    }
}