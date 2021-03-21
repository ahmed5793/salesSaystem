using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using clothesStore.DAL;
namespace clothesStore.Bl
{
    class Permession
    {
        internal void AddUserProduct(string User_Name, int Add_Prod, int Report_minItem, int check_Balance,int Report_checkBalance,int gard,int harka)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Prod", SqlDbType.Int);
            param[1].Value = Add_Prod;
            param[2] = new SqlParameter("@Report_minItem", SqlDbType.Int);
            param[2].Value = Report_minItem;
            param[3] = new SqlParameter("@check_Balance", SqlDbType.Int);
            param[3].Value = check_Balance;
            param[4] = new SqlParameter("@Report_checkBalance", SqlDbType.Int);
            param[4].Value = Report_checkBalance;
            param[5] = new SqlParameter("@Gard_Products", SqlDbType.Int);
            param[5].Value = gard;
            param[6] = new SqlParameter("@harkt_Seeling", SqlDbType.Int);
            param[6].Value = harka;
            da.excutequery("AddUserProduct", param);
            da.close();

        }
        internal void UpdateUserProduct(string User_Name, int Add_Prod, int Report_minItem, int check_Balance, int Report_checkBalance,int gard ,int harka)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Prod", SqlDbType.Int);
            param[1].Value = Add_Prod;
            param[2] = new SqlParameter("@Report_minItem", SqlDbType.Int);
            param[2].Value = Report_minItem;
            param[3] = new SqlParameter("@check_Balance", SqlDbType.Int);
            param[3].Value = check_Balance;
            param[4] = new SqlParameter("@Report_checkBalance", SqlDbType.Int);
            param[4].Value = Report_checkBalance;
            param[5] = new SqlParameter("@Gard_Products", SqlDbType.Int);
            param[5].Value = gard;
            param[6] = new SqlParameter("@harkt_Seeling", SqlDbType.Int);
            param[6].Value = harka;
            da.excutequery("UpdateUserProduct", param);
            da.close();

        }
        internal DataTable SelectUserProduct(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();

            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("SelectUserProduct", param);

            return dt;

        }



     
        internal void addUserClient(string User_Name, int add_Client, int check_Discount, int client_Pay, 
            int Depit_Client, int Account_Client ,int Sarf_Pay,int Client_Data)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@add_Client", SqlDbType.Int);
            param[1].Value = add_Client;
            param[2] = new SqlParameter("@check_Discount", SqlDbType.Int);
            param[2].Value = check_Discount;
            param[3] = new SqlParameter("@client_Pay", SqlDbType.Int);
            param[3].Value = client_Pay;
    
            param[4] = new SqlParameter("@Depit_Client", SqlDbType.Int);
            param[4].Value = Depit_Client;
            param[5] = new SqlParameter("@Account_Client", SqlDbType.Int);
            param[5].Value = Account_Client;
            param[6] = new SqlParameter("@Sarf_Pay", SqlDbType.Int);
            param[6].Value = Sarf_Pay;
            param[7] = new SqlParameter("@Client_Data", SqlDbType.Int);
            param[7].Value = Client_Data;
            da.excutequery("addUserClient", param);
            da.close();
        }
        internal void UpdateUserClient(string User_Name, int add_Client, int check_Discount, int client_Pay,
            int Depit_Client, int Account_Client,int Sarf_Pay,int Client_Data)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@add_Client", SqlDbType.Int);
            param[1].Value = add_Client;
            param[2] = new SqlParameter("@check_Discount", SqlDbType.Int);
            param[2].Value = check_Discount;
            param[3] = new SqlParameter("@client_Pay", SqlDbType.Int);
            param[3].Value = client_Pay;

            param[4] = new SqlParameter("@Depit_Client", SqlDbType.Int);
            param[4].Value = Depit_Client;
            param[5] = new SqlParameter("@Account_Client", SqlDbType.Int);
            param[5].Value = Account_Client;
            param[6] = new SqlParameter("@Sarf_Pay", SqlDbType.Int);
            param[6].Value = Sarf_Pay;
            param[7] = new SqlParameter("@Client_Data", SqlDbType.Int);
            param[7].Value = Client_Data;
            da.excutequery("UpdateUserClient", param);
            da.close();
        }
        internal DataTable SelectUserClient(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("SelectUserClient", param);
            return dt;
        }
        internal void AddUserSuppliers(string User_Name, int Add_Suppliers, int Report_DataSuppliers, int Check_DiscountSuppliers,
     int Pay_Suppliers, int Account_Suppliers,int Depit_Suppliers)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Suppliers", SqlDbType.Int);
            param[1].Value = Add_Suppliers;
            param[2] = new SqlParameter("@Report_DataSuppliers", SqlDbType.Int);
            param[2].Value = @Report_DataSuppliers;
            param[3] = new SqlParameter("@Check_DiscountSuppliers", SqlDbType.Int);
            param[3].Value = @Check_DiscountSuppliers;

            param[4] = new SqlParameter("@Pay_Suppliers", SqlDbType.Int);
            param[4].Value = Pay_Suppliers;
            param[5] = new SqlParameter("@Account_Suppliers", SqlDbType.Int);
            param[5].Value = Account_Suppliers;
            param[6] = new SqlParameter("@Depit_Suppliers", SqlDbType.Int);
            param[6].Value = Depit_Suppliers;
            da.excutequery("AddUserSuppliers", param);
            da.close();
        }

        internal void UpdateUserSuppliers(string User_Name, int Add_Suppliers, int Report_DataSuppliers, int Check_DiscountSuppliers,
   int Pay_Suppliers, int Account_Suppliers, int Depit_Suppliers)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Suppliers", SqlDbType.Int);
            param[1].Value = Add_Suppliers;
            param[2] = new SqlParameter("@Report_DataSuppliers", SqlDbType.Int);
            param[2].Value = @Report_DataSuppliers;
            param[3] = new SqlParameter("@Check_DiscountSuppliers", SqlDbType.Int);
            param[3].Value = @Check_DiscountSuppliers;

            param[4] = new SqlParameter("@Pay_Suppliers", SqlDbType.Int);
            param[4].Value = Pay_Suppliers;
            param[5] = new SqlParameter("@Account_Suppliers", SqlDbType.Int);
            param[5].Value = Account_Suppliers;
            param[6] = new SqlParameter("@Depit_Suppliers", SqlDbType.Int);
            param[6].Value = Depit_Suppliers;
            da.excutequery("UpdateUserSuppliers", param);
            da.close();
        }

        internal DataTable SelectUserSuppliers(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("SelectUserSuppliers", param);
            return dt;
        }

        internal void AddUserOrder(string User_Name, int Add_Order, int ReturnOrder, int ManagmentOrder,
                                   int ReportReturnOrder, int Report_Reb7Order)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Order", SqlDbType.Int);
            param[1].Value = Add_Order;
            param[2] = new SqlParameter("@ReturnOrder", SqlDbType.Int);
            param[2].Value = ReturnOrder;
            param[3] = new SqlParameter("@ManagmentOrder", SqlDbType.Int);
            param[3].Value = ManagmentOrder;

            param[4] = new SqlParameter("@ReportReturnOrder", SqlDbType.Int);
            param[4].Value = ReportReturnOrder;
            param[5] = new SqlParameter("@Report_Reb7Order", SqlDbType.Int);
            param[5].Value = Report_Reb7Order;
            
            da.excutequery("AddUserOrder", param);
            da.close();
        }

        internal void UpdateUserOrder(string User_Name, int Add_Order, int ReturnOrder, int ManagmentOrder,
                                   int ReportReturnOrder, int Report_Reb7Order)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Order", SqlDbType.Int);
            param[1].Value = Add_Order;
            param[2] = new SqlParameter("@ReturnOrder", SqlDbType.Int);
            param[2].Value = ReturnOrder;
            param[3] = new SqlParameter("@ManagmentOrder", SqlDbType.Int);
            param[3].Value = ManagmentOrder;

            param[4] = new SqlParameter("@ReportReturnOrder", SqlDbType.Int);
            param[4].Value = ReportReturnOrder;
            param[5] = new SqlParameter("@Report_Reb7Order", SqlDbType.Int);
            param[5].Value = Report_Reb7Order;

            da.excutequery("UpdateUserOrder", param);
            da.close();
        }
        internal DataTable selectUserOrder(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("selectUserOrder", param);
            return dt;
        }
        internal void AddUserPurshise(string User_Name, int Add_OrderSuppliers, int ReturnSuppliers, int ManagmentSuppliers,
                           int Report_ReturnSuppliers)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_OrderSuppliers", SqlDbType.Int);
            param[1].Value = Add_OrderSuppliers;
            param[2] = new SqlParameter("@ReturnSuppliers", SqlDbType.Int);
            param[2].Value = ReturnSuppliers;
            param[3] = new SqlParameter("@ManagmentSuppliers", SqlDbType.Int);
            param[3].Value = ManagmentSuppliers;

            param[4] = new SqlParameter("@Report_ReturnSuppliers", SqlDbType.Int);
            param[4].Value = Report_ReturnSuppliers;
            

            da.excutequery("AddUserPurshise", param);
            da.close();
        }
        internal void UpdateUserPurshise(string User_Name, int Add_OrderSuppliers, int ReturnSuppliers, int ManagmentSuppliers,
                     int Report_ReturnSuppliers)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_OrderSuppliers", SqlDbType.Int);
            param[1].Value = Add_OrderSuppliers;
            param[2] = new SqlParameter("@ReturnSuppliers", SqlDbType.Int);
            param[2].Value = ReturnSuppliers;
            param[3] = new SqlParameter("@ManagmentSuppliers", SqlDbType.Int);
            param[3].Value = ManagmentSuppliers;

            param[4] = new SqlParameter("@Report_ReturnSuppliers", SqlDbType.Int);
            param[4].Value = Report_ReturnSuppliers;


            da.excutequery("UpdateUserPurshise", param);
            da.close();
        }
        internal DataTable selectUserPurshise(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("selectUserPurshise", param);
            return dt;
        }


        internal void AddUserStock(string User_Name, int Add_Masrof, int Report_Masrof, int Add_Stock,
            int Insert_Stock, int Pull_Stock, int Report_pullStock, int Transfer_Stock, int Report_InsertStock)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Masrof", SqlDbType.Int);
            param[1].Value = Add_Masrof;
            param[2] = new SqlParameter("@Report_Masrof", SqlDbType.Int);
            param[2].Value = Report_Masrof;
            param[3] = new SqlParameter("@Add_Stock", SqlDbType.Int);
            param[3].Value = Add_Stock;

            param[4] = new SqlParameter("@Insert_Stock", SqlDbType.Int);
            param[4].Value = Insert_Stock;
            param[5] = new SqlParameter("@Pull_Stock", SqlDbType.Int);
            param[5].Value = Pull_Stock;

            param[6] = new SqlParameter("@Report_pullStock", SqlDbType.Int);
            param[6].Value = Report_pullStock;
            param[7] = new SqlParameter("@Transfer_Stock", SqlDbType.Int);
            param[7].Value = Transfer_Stock;
            param[8] = new SqlParameter("@Report_InsertStock", SqlDbType.Int);
            param[8].Value = Report_InsertStock;
            da.excutequery("AddUserStock", param);
            da.close();
        }

        internal void UpdateUserStock(string User_Name, int Add_Masrof, int Report_Masrof, int Add_Stock,
            int Insert_Stock, int Pull_Stock, int Report_pullStock, int Transfer_Stock, int Report_InsertStock)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@Add_Masrof", SqlDbType.Int);
            param[1].Value = Add_Masrof;
            param[2] = new SqlParameter("@Report_Masrof", SqlDbType.Int);
            param[2].Value = Report_Masrof;
            param[3] = new SqlParameter("@Add_Stock", SqlDbType.Int);
            param[3].Value = Add_Stock;

            param[4] = new SqlParameter("@Insert_Stock", SqlDbType.Int);
            param[4].Value = Insert_Stock;
            param[5] = new SqlParameter("@Pull_Stock", SqlDbType.Int);
            param[5].Value = Pull_Stock;

            param[6] = new SqlParameter("@Report_pullStock", SqlDbType.Int);
            param[6].Value = Report_pullStock;
            param[7] = new SqlParameter("@Transfer_Stock", SqlDbType.Int);
            param[7].Value = Transfer_Stock;
            param[8] = new SqlParameter("@Report_InsertStock", SqlDbType.Int);
            param[8].Value = Report_InsertStock;
            da.excutequery("UpdateUserStock", param);
            da.close();
        }
        internal DataTable selectUserStock(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 100);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("selectUserStock", param);
            return dt;
        }

        internal void AddUserFile(string User_Name, int BackUp, int Restore, int Setting,
        int Managment_User, int Managment_Employee)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@BackUp", SqlDbType.Int);
            param[1].Value = BackUp;
            param[2] = new SqlParameter("@Restore", SqlDbType.Int);
            param[2].Value = Restore;
            param[3] = new SqlParameter("@Managment_User", SqlDbType.Int);
            param[3].Value = Managment_User;

            param[4] = new SqlParameter("@Setting", SqlDbType.Int);
            param[4].Value = Setting;
            param[5] = new SqlParameter("@Managment_Employee", SqlDbType.Int);
            param[5].Value = Managment_Employee;


            da.excutequery("AddUserFile", param);
            da.close();
        }
        internal void UpdateUserFile(string User_Name, int BackUp, int Restore, int Setting,
        int Managment_User, int Managment_Employee)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[0].Value = User_Name;
            param[1] = new SqlParameter("@BackUp", SqlDbType.Int);
            param[1].Value = BackUp;
            param[2] = new SqlParameter("@Restore", SqlDbType.Int);
            param[2].Value = Restore;
            param[3] = new SqlParameter("@Managment_User", SqlDbType.Int);
            param[3].Value = Managment_User;

            param[4] = new SqlParameter("@Setting", SqlDbType.Int);
            param[4].Value = Setting;
            param[5] = new SqlParameter("@Managment_Employee", SqlDbType.Int);
            param[5].Value = Managment_Employee;


            da.excutequery("UpdateUserFile", param);
            da.close();
        }

        internal DataTable selectUserFile(string User_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 100);
            param[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = da.selected("selectUserFile", param);
            return dt;
        }
    }
}
