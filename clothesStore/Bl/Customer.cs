using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clothesStore.DAL;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace clothesStore.Bl
{
    class Customer
    {
        internal void addCustomer(string name,string address,string phone)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
        
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 150);
            param[0].Value = name;
            param[1] = new SqlParameter("@address", SqlDbType.NVarChar, 100);
            param[1].Value = address;
            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 20);
            param[2].Value = phone;
            da.excutequery("AddCustomer", param);
            da.close();
        }
        internal void Add_CustomerBalanceAccount(int id_cust)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Cust", SqlDbType.Int);
            param[0].Value = id_cust;
            da.excutequery("Add_CustomerBalanceAccount", param);
            da.close();
        }
        internal DataTable SelectCustomer()
        {
            DataTable dt = new DataTable();
            
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectCustomer", null);
            da.close();
            return dt;
        }
        internal DataTable Select_IdCustomer()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Select_IdCustomer", null);
            da.close();
            return dt;
        }
        internal DataTable Report_PayCustomer()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Report_PayCustomer", null);
            da.close();
            return dt;
        }
        internal DataTable search_PayCustomer(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("search_PayCustomer", param);
            da.close();
            return dt;
        }
        internal void DeleteCustomer(int id )
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
   


            da.excutequery("DeleteCustomer", param);
            da.close();
        }
        internal DataTable SearchCustomer(string name)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,100);
            param[0].Value = name;

            dt = da.selected("SearchCustomer", param);
            da.close();
            return dt;
        }
        internal void UpdateCustomer(string name,string address , string phone,int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,150);
            param[0].Value =name;
            param[1] = new SqlParameter("@address", SqlDbType.NVarChar,100);
            param[1].Value = address;
            param[2] = new SqlParameter("@phone", SqlDbType.VarChar,20);
            param[2].Value = phone;
            param[3] = new SqlParameter("@id", SqlDbType.Int);
            param[3].Value = id;
            da.excutequery("UpdateCustomer", param);
            da.close();
                

        }
        internal DataTable VildateCustomer(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idcust", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("VildateCustomer", param);
            da.close();
            return dt;
        }
        internal void Add_CustomerStatmentAccount(int id_cust, Decimal Da2n, decimal Maden, string Elbyan,DateTime Date , decimal Balance ,string SalesMan)
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID_Cast", SqlDbType.Int);
            param[0].Value = id_cust;
            param[1] = new SqlParameter("@Da2n", SqlDbType.Decimal);
            param[1].Value = Da2n;
            param[2] = new SqlParameter("@MADEN", SqlDbType.Decimal);
            param[2].Value = Maden;
            param[3] = new SqlParameter("@ELBYAN", SqlDbType.NVarChar,150);
            param[3].Value = Elbyan;
            param[4] = new SqlParameter("@DATA", SqlDbType.DateTime);
            param[4].Value = Date;
            param[5] = new SqlParameter("@BALANCE", SqlDbType.Decimal);
            param[5].Value = Balance;
            param[6] = new SqlParameter("@SalesMan", SqlDbType.NVarChar);
            param[6].Value = SalesMan;
            da.excutequery("Add_CustomerStatmentAccount", param);
            da.close();
        }
        internal void Update_CustomerTotalMoney(int id_cust, decimal Total_Balance)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Cust", SqlDbType.Int);
            param[0].Value = id_cust;
            param[1] = new SqlParameter("@Total_Balance", SqlDbType.Decimal);
            param[1].Value = Total_Balance;
            da.excutequery("Update_CustomerTotalMoney", param);
            da.close();
        }
        internal DataTable Select_CustomerBalance(int Id_Cust)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Cust", SqlDbType.Int);
            param[0].Value = Id_Cust;
            dt = da.selected("Select_CustomerBalance", param);
            da.close();
            return dt;
        }
        internal DataTable Select_OrderForCustomer(int id_Cust)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Customer", SqlDbType.Int);
            param[0].Value = id_Cust;
            dt = da.selected("Select_OrderForCustomer", param);
            da.close();
            return dt;
        }
        internal DataTable SelectReport_CustomerAccountStatement(int id_Cust)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Customer", SqlDbType.Int);
            param[0].Value = id_Cust;
            dt = da.selected("SelectReport_CustomerAccountStatement", param);
            da.close();
            return dt;
        }
        internal DataTable Report_CustomerAccountStatement(int id_Cust , DateTime Date_From , DateTime Date_to)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Customer", SqlDbType.Int);
            param[0].Value = id_Cust;
            param[1] = new SqlParameter("@Date_from", SqlDbType.Date);
            param[1].Value = Date_From;
            param[2] = new SqlParameter("@Date_to", SqlDbType.Date);
            param[2].Value = Date_to;
            dt = da.selected("Report_CustomerAccountStatement", param);
            da.close();
            return dt;
        }
        internal DataTable Report_AllCustomer()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Report_AllCustomer", null);
            da.close();
            return dt;
        }
        internal DataTable SelectDepit()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectDepit", null);
            da.close();
            return dt;
        }
    }

}
