using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clothesStore.DAL;
using System.Data;
using System.Data.SqlClient;


namespace clothesStore.Bl
{
    class Suppliers
    {
        internal void addSuppliers(  string name, string address, string phone)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
        
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            param[1] = new SqlParameter("@address", SqlDbType.NVarChar, 50);
            param[1].Value = address;
            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value = phone;


            da.excutequery("addSuppliers", param);
            da.close();
        }
        internal DataTable SelectSuppliers()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
           
            dt = da.selected("SelectSuppliers", null);
            da.close();
            return dt;
        }
        internal DataTable Report_PaySupplier()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();

            dt = da.selected("Report_PaySupplier", null);
            da.close();
            return dt;
        }
        internal DataTable Search_PaySupplier (string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("Search_PaySupplier", param);
            da.close();
            return dt;
        }

        internal DataTable CompoBox()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();

            dt = da.selected("CompoBox", null);
            da.close();
            return dt;
        }
        internal DataTable ComboBox_PaySuppliers()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();

            dt = da.selected("ComboBox_PaySuppliers", null);
            da.close();
            return dt;
        }
        internal DataTable CompoBoxSuppliers()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();

            dt = da.selected("CompoBoxSuppliers", null);
            da.close();
            return dt;
        }
        internal void DeleteSuppliers(int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;



            da.excutequery("DeleteSuppliers", param);
            da.close();
        }
        internal DataTable SearchSuppliers(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("SearchSuppliers", param);
            da.close();
            return dt;
        }
        internal void UpdateSuppliers(string name, string address, string phone, int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            param[1] = new SqlParameter("@address", SqlDbType.NVarChar, 50);
            param[1].Value = address;
            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value = phone;
            param[3] = new SqlParameter("@id", SqlDbType.Int);
            param[3].Value = id;
            da.excutequery("UpdateSuppliers", param);
            da.close();
        }
        internal DataTable LastSuppliersDetalis()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
           dt= da.selected("LastSuppliersDetalis", null);
            da.close();
            return dt;        
        }
        internal DataTable ListSuppliers()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("ListSuppliers", null);
            da.close();
            return dt;          
        }
        internal void addSuppliersDetails( int id,int IDProudect, decimal quantity,decimal prise, decimal amount, decimal discount,
                                           decimal totalAmount,string Product_Name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@idProd", SqlDbType.Int);
            param[1].Value = IDProudect;       
            param[2] = new SqlParameter("@quantity", SqlDbType.Decimal);
            param[2].Value = quantity;
            param[3] = new SqlParameter("@Price", SqlDbType.Decimal);
            param[3].Value = prise;
            param[4] = new SqlParameter("@Amount", SqlDbType.Decimal);
            param[4].Value = amount;
            param[5] = new SqlParameter("@Discount", SqlDbType.Decimal);
            param[5].Value = discount;
            param[6] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            param[6].Value = totalAmount;
            param[7] = new SqlParameter("@Prod_Name", SqlDbType.NVarChar,150);
            param[7].Value = Product_Name;
            da.excutequery("addSuppliersDetails", param);
            da.close();
        }
        internal void addMoneySupplier(int id_inform, decimal rent, int id_supp)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id_INFORMATION", SqlDbType.Int);
            param[0].Value = id_inform;
       
       
            param[1] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[1].Value = rent;
            param[2] = new SqlParameter("@sup_id", SqlDbType.Int);
            param[2].Value = id_supp;
            da.excutequery("addMoneySuplliers", param);
            da.close();
        }







          internal void ADDSuppliersINFORMARION(int SupID,DateTime date,string note,string salesMan,
              decimal  total_invoic,decimal pay ,decimal rent, int Id_Stock)
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@sup_id", SqlDbType.Int);
            param[0].Value = SupID;
            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@note", SqlDbType.NVarChar,350);
            param[2].Value = note;
            param[3] = new SqlParameter("@salesMan", SqlDbType.NVarChar,50);
            param[3].Value = salesMan;
            param[4] = new SqlParameter("@Total_Invoic", SqlDbType.Decimal);
            param[4].Value = total_invoic;
            param[5] = new SqlParameter("@pay", SqlDbType.Decimal);
            param[5].Value = pay;
            param[6] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[6].Value = rent;
            param[7] = new SqlParameter("@id_stock", SqlDbType.Int);
            param[7].Value = Id_Stock;
            da.excutequery("ADDSuppliersINFORMARION", param);
            da.close();

        }

        internal DataTable Purchase()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("Purchase", null);
            da.close();
            return dt;

        }

        internal DataTable ReturncompoSupplier()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            dt=da.selected("ReturncompoSupplier", null);
            da.close();
            return dt;
        }

        internal DataTable SelectSuppliersRteurn(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectSuppliersRteurn", param);
            da.close();
            return dt;
        }
        internal DataTable reportsupplier(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("reportsupplier", param);
            da.close();
            return dt;
        }
        internal DataTable reportsupplierprod(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("reportsupplierprod", param);
            da.close();
            return dt;
        }
        internal DataTable returnSuppliersText()
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
     

            dt = da.selected("returnSuppliersText", null);
            da.close();
            return dt;
        }

        internal DataTable suppliermanagement()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("suppliermanagement", null);
            da.close();
            return dt;
        }

        internal DataTable SearchSuppliermanagement(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("SearchSuppliermanagement", param);
            da.close();
            return dt;
        }


        internal DataTable RentSuppliers(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("RentSuppliers", param);
            da.close();
            return dt;
        }

        internal DataTable SelectIdSuppliers()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("SelectIdSuppliers", null);
            da.close();
            return dt;

        }

        internal void AddPaySuppliers(int id_sup,decimal pay, DateTime date ,string Sales_Man)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id_suppliers", SqlDbType.Int);
            param[0].Value = id_sup;
            param[1] = new SqlParameter("@Pay", SqlDbType.Decimal);
            param[1].Value = pay;
            param[2] = new SqlParameter("@date", SqlDbType.DateTime);
            param[2].Value = date;
            param[3] = new SqlParameter("@Sales_Man", SqlDbType.NVarChar,50);
            param[3].Value = Sales_Man;
            da.excutequery("AddPaySuppliers", param);
            da.close();

        }
        internal DataTable SelectProudectRteurn(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectProductsRteurn", param);
            da.close();
            return dt;
        }
        internal void UpdateSuppliersINformation(int id, int idProd, int quantity, decimal prise, decimal amount, decimal discount, decimal totalAmount)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@idProd", SqlDbType.Int);
            param[1].Value = idProd;
            param[2] = new SqlParameter("@quantity", SqlDbType.Int);
            param[2].Value = quantity;
            param[3] = new SqlParameter("@price", SqlDbType.Decimal);
            param[3].Value = prise;
            param[4] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[4].Value = amount;
            param[5] = new SqlParameter("@discount", SqlDbType.Decimal);
            param[5].Value = discount;
            param[6] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            param[6].Value = totalAmount;
            da.excutequery("UpdateSuppliersINformation", param);
            da.close();


        }
        internal void UpdateMONEYSyppliers(int id,decimal totalInvo, decimal pay, decimal rent)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4]; 
             param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@totalInv", SqlDbType.Decimal);
            param[1].Value = totalInvo;
            param[2] = new SqlParameter("@pay", SqlDbType.Decimal);
            param[2].Value = pay;
            param[3] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[3].Value = rent;

            da.excutequery("UpdateMONEYSyppliers", param);
            da.close();


        }

        internal void AddReturn(int id_order, int Id_Suppliers, int id_pro, decimal Return_quantity, DateTime Return_date,
                               decimal price, decimal amount, string Sales_Man)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID_Information", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@Id_Suppliers", SqlDbType.Int);
            param[1].Value = Id_Suppliers;
            param[2] = new SqlParameter("@ID_Prou", SqlDbType.Int);
            param[2].Value = id_pro;
            param[3] = new SqlParameter("@Return_Quantity", SqlDbType.Decimal);
            param[3].Value = Return_quantity;
            param[4] = new SqlParameter("@date_Return", SqlDbType.DateTime);
            param[4].Value = Return_date;
            param[5] = new SqlParameter("@Price", SqlDbType.Decimal);
            param[5].Value = price;
            param[6] = new SqlParameter("@Amount", SqlDbType.Decimal);
            param[6].Value = amount;
            param[7] = new SqlParameter("@Sales_man", SqlDbType.NVarChar, 50);
            param[7].Value = Sales_Man;         
            da.excutequery("AddReturn", param);
            da.close();
        }


        internal DataTable SelectSuppliersMony()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("SelectSuppliersMony", null);
            da.close();
            return dt;

        }
        internal DataTable SelectOneSuppliersMony(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_sup", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectOneSuppliersMony", param);
            da.close();
            return dt;
        }

        internal DataTable DeleteSuppliersrMoney(int id_Informa)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id_Informa;

            dt = da.selected("DeleteSuppliersrMoney", param);
            da.close();
            return dt;
        }

        internal void UpdatePartSuppliers(int id_info,decimal rent)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id_inform", SqlDbType.Int);
            param[0].Value = id_info;
            param[1] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[1].Value = rent;
     


            da.excutequery("UpdatePartSuppliers", param);
            da.close();
        }
        internal DataTable SearchsuppliermanagementSystem(DateTime DateFrom, DateTime DateTo)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = DateFrom;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = DateTo;
         
            dt = da.selected("SearchsuppliermanagementSystem", param);
            da.close();
            return dt;
        }

        internal DataTable Select_DepitSupplier()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Select_DepitSupplier", null);
            return dt;
        }
        internal DataTable SearchListSuppliers(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("SearchListSuppliers", param);
            da.close();
            return dt;
        }
        internal DataTable VildateID_Supplirs(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_suppliers", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("VildateID_Supplirs", param);
            da.close();
            return dt;
        }
        

        internal void AddReturnSuppliersUnUseds(int idinformation,int idProd, int Quantity,DateTime date)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idinformation;
            param[1] = new SqlParameter("@idProd", SqlDbType.Int);
            param[1].Value = idProd;
            param[2] = new SqlParameter("@Quantity", SqlDbType.Int);
            param[2].Value = Quantity;
            param[3] = new SqlParameter("@date", SqlDbType.DateTime);
            param[3].Value = date;
            da.excutequery("AddReturnSuppliersUnUseds", param);
            da.close();


        }


        internal DataTable SelectValueTableSuppliersReturnm()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectValueTableSuppliersReturnm", null);
            return dt;
        }
        internal DataTable DeleteTableSuppliersReturnm()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("DeleteTableSuppliersReturnm", null);
            return dt;
        }

        internal DataTable selectTableSuppliersReturnm(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idsupplierInfo", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("selectTableSuppliersReturnm", param);
            da.close();
            return dt;
        }

        internal void UpdateProudectSuppliers( int idProd, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
       
            param[0] = new SqlParameter("@IDProudect", SqlDbType.Int);
            param[0].Value = idProd;
            param[1] = new SqlParameter("@quntity", SqlDbType.Decimal);
            param[1].Value = Quantity;
         
            da.excutequery("UpdateProudectSuppliers", param);
            da.close();
        }
        internal DataTable VildateSuppliers(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idSuppliersd", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("VildateSuppliers", param);
            da.close();
            return dt;
        }
        internal DataTable Select_LastIdSupplier()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Select_LastIdSupplier", null);
            return dt;
        }
        internal void Add_SupplierTotalMoney(int Id_Suppliers)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = Id_Suppliers;
            da.excutequery("Add_SupplierTotalMoney", param);
            da.close();
        }
        internal void Add_SuppliersStatementAccount(int id_Supplier, Decimal Da2n, decimal Maden, string Elbyan, DateTime Date, decimal Balance)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = id_Supplier;
            param[1] = new SqlParameter("@Da2n", SqlDbType.Decimal);
            param[1].Value = Da2n;
            param[2] = new SqlParameter("@maden", SqlDbType.Decimal);
            param[2].Value = Maden;
            param[3] = new SqlParameter("@elbyan", SqlDbType.NVarChar, 150);
            param[3].Value = Elbyan;
            param[4] = new SqlParameter("@date", SqlDbType.DateTime);
            param[4].Value = Date;
            param[5] = new SqlParameter("@Balance", SqlDbType.Decimal);
            param[5].Value = Balance;
            da.excutequery("Add_SuppliersStatementAccount", param);
            da.close();
        }
        internal DataTable select_SupplierBalance(int Id_Supplier)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = Id_Supplier;
            dt = da.selected("select_SupplierBalance", param);
            da.close();
            return dt;
        }
        internal void Update_SupplierTotalMoney(int id_Supplier, decimal Total_Balance)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = id_Supplier;
            param[1] = new SqlParameter("@total_Mony", SqlDbType.Decimal);
            param[1].Value = Total_Balance;
            da.excutequery("Update_SupplierTotalMoney", param);
            da.close();
        }
        internal DataTable Validate_IdSupplierinnoice(int Id_SupplierInnvoice)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_SupplierInnvoice", SqlDbType.Int);
            param[0].Value = Id_SupplierInnvoice;

            dt = da.selected("Validate_IdSupplierinnoice", param);
            da.close();
            return dt;
        }
        internal DataTable Select_OldReturnSupplier(int Id_information)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Information", SqlDbType.Int);
            param[0].Value = Id_information;

            dt = da.selected("Select_OldReturnSupplier", param);
            da.close();
            return dt;
        }
        internal DataTable Select_SupplierInformationForSupplier(int ID_Supplier)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Supplier", SqlDbType.Int);
            param[0].Value = ID_Supplier;

            dt = da.selected("Select_SupplierInformationForSupplier", param);
            da.close();
            return dt;
        }
        internal DataTable SelectReport_SupplierAccountStatement(int id_Supplier)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = id_Supplier;
            dt = da.selected("SelectReport_SupplierAccountStatement", param);
            da.close();
            return dt;
        }
        internal DataTable Report_SupplierAccountStatement(int id_Supplier, DateTime Date_From, DateTime Date_to)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Supplier", SqlDbType.Int);
            param[0].Value = id_Supplier;
            param[1] = new SqlParameter("@Date_from", SqlDbType.Date);
            param[1].Value = Date_From;
            param[2] = new SqlParameter("@Date_to", SqlDbType.Date);
            param[2].Value = Date_to;
            dt = da.selected("Report_SupplierAccountStatement", param);
            da.close();
            return dt;
        }
        internal DataTable ReportAllSuppliers()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("ReportAllSuppliers", null);
            return dt;
        }
        internal DataTable Report_ReturnPurshasing()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
         
            dt = da.selected("Report_ReturnPurshasing",null);
            da.close();
            return dt;
        }
        internal DataTable Search_ReportReturnPurshasing(DateTime Date_From, DateTime Date_To)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = Date_From;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = Date_To;
       
            DataTable dt = new DataTable();
            dt = da.selected("Search_ReportReturnPurshasing", param);
            da.close();
            return dt;
        }
    }

}
