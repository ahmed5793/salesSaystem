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
    public partial class Validate_Users : Form
    {
        //Frm_Main Frm = new Frm_Main();
     
        Permession p = new Permession();
        Login l = new Login();
        DataTable dt = new DataTable();
        DataTable dt10 = new DataTable();
        DataTable dt2 = new DataTable();

        

        public Validate_Users()
        {
            InitializeComponent();
            selectUser();




        } 
        void selectUser()
        {
            try
            {

            cmb_Users1.DataSource = l.SelectUsers();
            cmb_Users1.DisplayMember = "اسم المستخدم";
            cmb_Users1.ValueMember = "اسم المستخدم";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void cmb_Users1_SelectionChangeCommitted(object sender, EventArgs e)
        {          
            try
            {
                if (cmb_Users1.Text != "")
                {



                    dt2.Clear();
                    dt2 = p.SelectUserProduct(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_AddItems.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_AddItems.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_reportMinItem.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_reportMinItem.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_Balance.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_Balance.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_ReportBalance.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_ReportBalance.Checked = true; }
                        /////////

                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_Gard.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_Gard.Checked = true; }
                        /////////
                        ///
                        if (Convert.ToInt32(dt2.Rows[0][6]) == 0) { check_7arka.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][6]) == 1) { check_7arka.Checked = true; }
                        /////////

                    }

                    dt2.Clear();
                    dt2 = p.SelectUserClient(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_AddClient.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_AddClient.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { Check_DiscountClient.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { Check_DiscountClient.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { Check_PayClient.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { Check_PayClient.Checked = true; }

                        /////////
                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { Check_DepitClient.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { Check_DepitClient.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_ReportAccountCliet.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_ReportAccountCliet.Checked = true; }

                        if (Convert.ToInt32(dt2.Rows[0][6]) == 0) { check_SarfPay.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][6]) == 1) { check_SarfPay.Checked = true; }

                        if (Convert.ToInt32(dt2.Rows[0][7]) == 0) { check_ClientData.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][7]) == 1) { check_ClientData.Checked = true; }

                    }
                    dt2.Clear();
                    dt2 = p.SelectUserSuppliers(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_AddSuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_AddSuppliers.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_ReportSuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_ReportSuppliers.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_DiscountSuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_DiscountSuppliers.Checked = true; }

                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_PaySuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_PaySuppliers.Checked = true; }
                        /////////
                  
                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_REportAccountSuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_REportAccountSuppliers.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][6]) == 0) { check_DepitSuppliers.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][6]) == 1) { check_DepitSuppliers.Checked = true; }
                    }
                    dt2.Clear();
                    dt2 = p.selectUserOrder(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_InvoiceOrder.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_InvoiceOrder.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_ReturnOrder.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_ReturnOrder.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_managmentOrder.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_managmentOrder.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_ReportReturnOrder.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_ReportReturnOrder.Checked = true; }
                        /////////
                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_reb7Order.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_reb7Order.Checked = true; }

                    }
                    dt2.Clear();
                    dt2 = p.selectUserPurshise(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_InvoiceSupplier.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_InvoiceSupplier.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_ReturnSuppliers.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_ReturnSuppliers.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_ManagmentSuppliers.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_ManagmentSuppliers.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_ReportReturnSuppliers.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_ReportReturnSuppliers.Checked = true; }

                    }
                    dt2.Clear();
                    dt2 = p.selectUserStock(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_AddMasrof.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_AddMasrof.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_ReportMasrof.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_ReportMasrof.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_AddStock.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_AddStock.Checked = true; }
                        ///////

                     
                        ///

                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_AddStockMoney.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_AddStockMoney.Checked = true; }
                        /////
                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_PullStockMoney.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_PullStockMoney.Checked = true; }
                        /////////
                        if (Convert.ToInt32(dt2.Rows[0][6]) == 0) { check_ReportPullStockMoney.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][6]) == 1) { check_ReportPullStockMoney.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][7]) == 0) { check_TransferStock.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][7]) == 1) { check_TransferStock.Checked = true; }
                        //////
                        if (Convert.ToInt32(dt2.Rows[0][8]) == 0) { check_ReportAddStockMoney.Checked = false; }

                        else if (Convert.ToInt32(dt2.Rows[0][8]) == 1) { check_ReportAddStockMoney.Checked = true; }
                        ///////
                        
                    }
                    dt2.Clear();
                    dt2 = p.selectUserFile(cmb_Users1.Text);
                    if (dt2.Rows.Count >= 1)
                    {
                        if (Convert.ToInt32(dt2.Rows[0][1]) == 0) { check_BackUp.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][1]) == 1) { check_BackUp.Checked = true; }
                        ///////
                        if (Convert.ToInt32(dt2.Rows[0][2]) == 0) { check_Restore.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][2]) == 1) { check_Restore.Checked = true; }
                        ////////
                        if (Convert.ToInt32(dt2.Rows[0][3]) == 0) { check_SettingPrint.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][3]) == 1) { check_SettingPrint.Checked = true; }
                        ///////

                        if (Convert.ToInt32(dt2.Rows[0][4]) == 0) { check_ManagmentUser.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][4]) == 1) { check_ManagmentUser.Checked = true; }
                        /////
                        if (Convert.ToInt32(dt2.Rows[0][5]) == 0) { check_ManagmentEmployee.Checked = false; }
                        else if (Convert.ToInt32(dt2.Rows[0][5]) == 1) { check_ManagmentEmployee.Checked = true; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }


        private void Validate_Users_Load(object sender, EventArgs e)
        {
           
        }



        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم الموظف");
                    return;
                }
                else
                {
                    int AddItem = 0, reportMinItem = 0, Balance = 0, ReportBalance = 0, gard=0,harka=0;
                    if (check_AddItems.Checked == true){ AddItem = 1;}
                    else if (check_AddItems.Checked == false){ AddItem = 0;}
                    /////
                    if (check_reportMinItem.Checked == true){ reportMinItem = 1;}
                    else if (check_reportMinItem.Checked == false){ reportMinItem = 0;}
                    /////
                    if (check_Balance.Checked == true){ Balance = 1;}
                    else if (check_Balance.Checked == false){ Balance = 0;}
                    ////
                    if (check_ReportBalance.Checked == true){ ReportBalance = 1;}
                    else if (check_ReportBalance.Checked == false){ ReportBalance = 0;}
                    ////////djaklsjdaklda
                    if (check_Gard.Checked == true) { gard = 1; }
                    else if (check_Gard.Checked == false) { gard = 0; }
                    ////////
                    if (check_7arka.Checked == true) { harka = 1; }
                    else if (check_7arka.Checked == false) { harka = 0; }
                    ////////


                    p.UpdateUserProduct(cmb_Users1.Text, AddItem, reportMinItem, Balance, ReportBalance,gard, harka);



                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم المستخدم");
                    return;
                }
                else
                {
                    int AddClient = 0, DiscountClient = 0, PayClient = 0, DepitClient = 0, ReportAccountCliet = 0
                        ,sarfPay=0, ClientData=0;

                    if (check_AddClient.Checked == true){ AddClient = 1;}
                    else if (check_AddClient.Checked == false){ AddClient = 0;}
                    //////
                    if (Check_DiscountClient.Checked == true){ DiscountClient = 1;}
                    else if (Check_DiscountClient.Checked == false){ DiscountClient = 0;}
                    //////
                    if (Check_PayClient.Checked == true){ PayClient = 1;}
                    else if (Check_PayClient.Checked == false){ PayClient = 0;}
                    //////
                    if (check_ReportAccountCliet.Checked == true){ ReportAccountCliet = 1;}
                    else if (check_ReportAccountCliet.Checked == false){ ReportAccountCliet = 0;}


                    if (check_SarfPay.Checked == true) { sarfPay = 1; }
                    else if (check_SarfPay.Checked == false) { sarfPay = 0; }

                    if (check_ClientData.Checked == true) { ClientData = 1; }
                    else if (check_ClientData.Checked == false) { ClientData = 0; }

                    p.UpdateUserClient(cmb_Users1.Text, AddClient, DiscountClient, PayClient, DepitClient, ReportAccountCliet, sarfPay, ClientData);
                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم الموظف");
                    return;
                }
                else
                {
                    int AddSuppliers = 0, ReportSuppliers = 0, DiscountSuppliers = 0, PaySuppliers = 0, REportAccountSuppliers = 0,
                        DepitSuppliers = 0;

                    if (check_AddSuppliers.Checked == true){ AddSuppliers = 1;}

                    else if (check_AddSuppliers.Checked == false){ AddSuppliers = 0;}
                    ///////
                    if (check_ReportSuppliers.Checked == true){ ReportSuppliers = 1;}

                    else if (check_ReportSuppliers.Checked == false){ ReportSuppliers = 0;}
                    ///////
                    if (check_DiscountSuppliers.Checked == true){ DiscountSuppliers = 1;}

                    else if (check_DiscountSuppliers.Checked == false){ DiscountSuppliers = 0;}
                    ////////
                    if (check_PaySuppliers.Checked == true){ PaySuppliers = 1;}

                    else if (check_PaySuppliers.Checked == false){ PaySuppliers = 0;}
                    ////////
                    if (check_REportAccountSuppliers.Checked == true){ REportAccountSuppliers = 1;}

                    else if (check_REportAccountSuppliers.Checked == false){ REportAccountSuppliers = 0;}
                    //////
                    if (check_DepitSuppliers.Checked == true){ DepitSuppliers = 1;}

                    else if (check_DepitSuppliers.Checked == false){ DepitSuppliers = 0;}
                    //////
                 
                    p.UpdateUserSuppliers(cmb_Users1.Text, AddSuppliers, ReportSuppliers, DiscountSuppliers, PaySuppliers, REportAccountSuppliers,
                                         DepitSuppliers);


                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم المستخدم");
                    return;
                }
                else
                {
                    int InvoiceOrder = 0, ReturnOrder = 0, managmentOrder = 0, reb7Order = 0, ReportReturnOrder = 0;
                       

                    if (check_InvoiceOrder.Checked == true){ InvoiceOrder = 1;}

                    else if (check_InvoiceOrder.Checked == false){ InvoiceOrder = 0;}
                    ////////
                    if (check_ReturnOrder.Checked == true){ ReturnOrder = 1;}

                    else if (check_ReturnOrder.Checked == false){ ReturnOrder = 0;}
                    ///////
                    if (check_managmentOrder.Checked == true){ managmentOrder = 1;}

                    else if (check_managmentOrder.Checked == false){ managmentOrder = 0;}
                    ///////
                    if (check_reb7Order.Checked == true){ reb7Order = 1;}

                    else if (check_reb7Order.Checked == false){ reb7Order = 0;}
                    ////////
                    if (check_ReportReturnOrder.Checked == true){ ReportReturnOrder = 1;}

                    else if (check_ReportReturnOrder.Checked == false){ ReportReturnOrder = 0;}
                    /////////
                  

                    p.UpdateUserOrder(cmb_Users1.Text, InvoiceOrder, ReturnOrder, managmentOrder, ReportReturnOrder, reb7Order);

                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم الموظف");
                    return;
                }
                else
                {
                    int InvoiceSupplier = 0, ReturnSuppliers = 0, mnagmentSuppliers = 0,ReportReturnSuppliers = 0;

                    if (check_InvoiceSupplier.Checked == true){ InvoiceSupplier = 1;}

                    else if (check_InvoiceSupplier.Checked == false){ InvoiceSupplier = 0;}
                    //////
                    if (check_ReturnSuppliers.Checked == true){ ReturnSuppliers = 1;}

                    else if (check_ReturnSuppliers.Checked == false){ ReturnSuppliers = 0;}
                    /////
                    if (check_ManagmentSuppliers.Checked == true){ mnagmentSuppliers = 1;}

                    else if (check_ManagmentSuppliers.Checked == false){ mnagmentSuppliers = 0;}
                    /////
                    if (check_ReportReturnSuppliers.Checked == true){ ReportReturnSuppliers = 1;}

                    else if (check_ReportReturnSuppliers.Checked == false){ ReportReturnSuppliers = 0;}
                    ////////
               
                    
                    p.UpdateUserPurshise(cmb_Users1.Text, InvoiceSupplier, ReturnSuppliers, mnagmentSuppliers, ReportReturnSuppliers);

                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم الموظف");
                    
                    return;
                }
                else
                {
                    int AddMasrof = 0, ReportMasrof = 0, Add_Stock = 0, AddStockMoney = 0 , PullStockMoney = 0, ReportPullStockMoney = 0,
                        ReportTransferStock = 0, ReportAddStockMoney = 0; 

                    if (check_AddMasrof.Checked == true){ AddMasrof = 1;}
                    else if (check_AddMasrof.Checked == false){ AddMasrof = 0;}
                    //////
                    if (check_ReportMasrof.Checked == true){ ReportMasrof = 1;}
                    else if (check_ReportMasrof.Checked == false){ ReportMasrof = 0;}
                    //////
                    if (check_AddStock.Checked == true){ Add_Stock = 1;}
                    else if (check_AddStock.Checked == false){ Add_Stock = 0;}
                    //////
                    if (check_AddStockMoney.Checked == true) { AddStockMoney = 1; }
                    else if (check_AddStockMoney.Checked == false) { AddStockMoney = 0; }
                    /////
                    if (check_PullStockMoney.Checked == true){ PullStockMoney = 1;}
                    else if (check_PullStockMoney.Checked == false){ PullStockMoney = 0;}
                    ////////
                    if (check_ReportPullStockMoney.Checked == true){ ReportPullStockMoney = 1;}
                    else if (check_ReportPullStockMoney.Checked == false){ ReportPullStockMoney = 0;}
                   /////
                    if (check_TransferStock.Checked == true){ ReportTransferStock = 1;}
                    else if (check_TransferStock.Checked == false){ ReportTransferStock = 0;}
                    /////
                    if (check_ReportAddStockMoney.Checked == true){ ReportAddStockMoney = 1;}
                    else if (check_ReportAddStockMoney.Checked == false){ ReportAddStockMoney = 0;}


                

                    p.UpdateUserStock(cmb_Users1.Text, AddMasrof, ReportMasrof, Add_Stock, AddStockMoney, PullStockMoney, ReportPullStockMoney,
                                          ReportTransferStock, ReportAddStockMoney);



                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cmb_Branch_SelectionChangeCommitted(object sender, EventArgs e)
        {

          
        }
        void Check()
        {
            
            
            //check_AddBranch.Checked = false;
            //check_AddClients.Checked = false;
            //check_AddSuppliers.Checked = false;
            //check_AddEmployee.Checked = false;
            //check_AddEmployeeBranch.Checked = false;
            //check_AddInstalment.Checked = false;
            //check_ReportSuppliers.Checked = false;
            //check_InvoiceOrder.Checked = false;
            //check_AddProudect.Checked = false;
            //check_AddPurshase.Checked = false;
            //check_managmentOrder.Checked = false;
            //check_AddStore.Checked = false;
            //check_AddStoreProduct.Checked = false;
            //check_AddSuppliers.Checked = false;
            //check_AddTechnical.Checked = false;
            //check_AddTickets.Checked = false;
            //check_BookingTimes.Checked = false;
            //check_CustomerAccountStatment.Checked = false;
            //check_DiscountSuppliers.Checked = false;
            //check_DepitClients.Checked = false;
            //check_DepitSuppliuers.Checked = false;
            //check_DownloadFinger.Checked = false;
            //check_reb7Order.Checked = false;
            //check_ManagmentTickets.Checked = false;
            //check_Order.Checked = false;
            //check_PayClients.Checked = false;
            //check_PaySuppliers.Checked = false;
            //check_PaySupplies.Checked = false;
            //check_ReportReturnOrder.Checked = false;
            //check_RepoDoctorOut.Checked = false;
            //check_REportAccountSuppliers.Checked = false;
            //check_ReportDoctorOfCenter.Checked = false;
            //check_ReportAccountCliet.Checked = false;
            //check_ReportFinger.Checked = false;
            //check_ReportInsertStock.Checked = false;
            //check_ReportInstalment.Checked = false;
            //check_ReturnOrder.Checked = false;
            //check_ReportProudect.Checked = false;
            //check_ReportPullStock.Checked = false;
            //check_ReportPurshases.Checked = false;
            //check_ReportSuppliers.Checked = false;
            //check_ReportTechnical.Checked = false;
            //check_ReurnPurchise.Checked = false;
            //check_SearchTickets.Checked = false;
            //check_TranfairStockToStock.Checked = false;
            //check_TransfairProduct.Checked = false;
            //Ckeck_ReciveMoney.Checked = false;
            //Check_AddDoctor.Checked = false;
            //Check_DepitClient.Checked = false;
            //Check_AddShiftTechincal.Checked = false;
            //Check_AddUserAccount.Checked = false;
            //Check_Add_CategoryXray.Checked = false;
            //Check_Add_ShiftEmployee.Checked = false;
            //Check_Add_Xray.Checked = false;
            //Check_DiscountClient.Checked = false;
            //Check_PayClient.Checked = false;
            //Check_Sarf_Mortbat.Checked = false;
            //Check_UserPermession.Checked = false;

        }

        private void cmb_Users1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Users1.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد إسم الموظف");

                    return;
                }
                else
                {
                    int BackUp = 0, Restore = 0, SettingPrint = 0, ManagmentUser = 0, ManagmentEmployee = 0;

                    if (check_BackUp.Checked == true) { BackUp = 1; }
                    else if (check_BackUp.Checked == false) { BackUp = 0; }
                    //////
                    if (check_Restore.Checked == true) { Restore = 1; }
                    else if (check_Restore.Checked == false) { Restore = 0; }
                    //////
                    if (check_SettingPrint.Checked == true) { SettingPrint = 1; }
                    else if (check_SettingPrint.Checked == false) { SettingPrint = 0; }
                    //////
                    if (check_ManagmentUser.Checked == true) { ManagmentUser = 1; }
                    else if (check_ManagmentUser.Checked == false) { ManagmentUser = 0; }
                    /////
                    if (check_ManagmentEmployee.Checked == true) { ManagmentEmployee = 1; }
                    else if (check_ManagmentEmployee.Checked == false) { ManagmentEmployee = 0; }
                    /////

                    p.UpdateUserFile(cmb_Users1.Text, BackUp, Restore, SettingPrint, ManagmentUser, ManagmentEmployee);



                    MessageBox.Show(" تم حفظ الصلاحيات للمستخدم");



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
