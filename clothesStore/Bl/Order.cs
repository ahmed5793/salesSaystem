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
    class Order
    {
        internal DataTable LastId()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            dt = da.selected("LastOrder", null);
            da.close();
            return dt;
        }
        internal DataTable SelectCompoCustomer()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("SelectCompoCustomer", null);
            da.close();
            return dt;
        }
        internal DataTable SelectCustName()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("SelectCustName", null);
            da.close();
            return dt;
        }
        internal DataTable SelectCustNameSarfPay()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            dt = da.selected("SelectCustNameSarfPay", null);
            da.close();
            return dt;
        }
        internal void AddOrder(DateTime date_order,int idCust, string discraption,string salesMan, decimal totalinvo, decimal pay, 
                                decimal rent,int id_Stock)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@date_order", SqlDbType.DateTime);
            param[0].Value = date_order;
            param[1] = new SqlParameter("@discription", SqlDbType.NVarChar,250);
            param[1].Value = discraption;
            param[2] = new SqlParameter("@salesMan", SqlDbType.NVarChar,50);
            param[2].Value = salesMan;
            param[3] = new SqlParameter("@id_cust", SqlDbType.Int);
            param[3].Value = idCust;
            param[4] = new SqlParameter("@Total_Invoic", SqlDbType.Decimal);
            param[4].Value = totalinvo;
            param[5] = new SqlParameter("@pay", SqlDbType.Decimal);
            param[5].Value = pay;
            param[6] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[6].Value = rent;
            param[7] = new SqlParameter("@Id_Stock", SqlDbType.Int);
            param[7].Value = id_Stock;
            da.excutequery("AddOrder", param); 
            da.close(); 
        }
        internal void AddOrderDetails(int IDOrder,int IDProudect,string name ,decimal quantity,decimal prise,decimal discount
                                      ,decimal amount,decimal totalAmount)
        {
    
            DataAccessLayer da = new DataAccessLayer();

            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@IDOrder", SqlDbType.Int);
            param[0].Value = IDOrder;
            param[1] = new SqlParameter("@IDProudect", SqlDbType.Int);
            param[1].Value = IDProudect;
            param[2] = new SqlParameter("@Prod_Name", SqlDbType.NVarChar,150);
            param[2].Value = name;
            param[3] = new SqlParameter("@quntity", SqlDbType.Decimal);
            param[3].Value = quantity;
            param[4] = new SqlParameter("@Price", SqlDbType.Decimal);
            param[4].Value = prise;
            param[5] = new SqlParameter("@Discount", SqlDbType.Decimal);
            param[5].Value = discount;
            param[6] = new SqlParameter("@Amount", SqlDbType.Decimal);
            param[6].Value = amount;
            param[7] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            param[7].Value = totalAmount;
            da.excutequery("AddOrderDetails", param);
            da.close();            
        }
        internal void addMoney(int id,decimal rent,int idcast)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
           
            param[1] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[1].Value = rent;
            param[2] = new SqlParameter("@id_cast", SqlDbType.Int);
            param[2].Value = idcast;
            da.excutequery("addMoney", param);
            da.close();
        }
        internal DataTable verviyQuantity(int id,int quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            DataTable dt = new DataTable();
            param[0] = new SqlParameter("@idProudect", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@quantity", SqlDbType.Int);
            param[1].Value = quantity;
            dt = da.selected("verviyQuantity", param);
            return dt;

        }
        internal DataTable SelectOrderManagment()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            
            
            dt = da.selected("SelectOrderManagment", null);
            da.close();
            return dt;
        }

        internal DataTable SearchOrderManagment(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            dt = da.selected("SearchOrderManagment", param);
            da.close();
            return dt;
        }

        internal DataTable SearchOrderManagmentSystem(DateTime DateFrom , DateTime DateTo)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = DateFrom;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = DateTo;
          
            dt = da.selected("SearchOrderManagmentSystem", param);
            da.close();
            return dt;
        }
        internal DataTable SearchSalesReb7ForOneStore(int Id_Store,DateTime DateFrom, DateTime DateTo)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Store", SqlDbType.Int);
            param[0].Value = Id_Store;
            param[1] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[1].Value = DateFrom;
            param[2] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[2].Value = DateTo;
            dt = da.selected("SearchSalesReb7ForOneStore", param);
            da.close();
            return dt;
        }
        internal DataTable SearchSalesReb7(DateTime DateFrom, DateTime DateTo)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
            param[0].Value = DateFrom;
            param[1] = new SqlParameter("@DateTo", SqlDbType.DateTime);
            param[1].Value = DateTo;
            dt = da.selected("SearchSalesReb7", param);
            da.close();
            return dt;
        }

        internal DataTable SelectIdOrder()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();

            dt = da.selected("SelectIdOrder", null);
            da.close();
            return dt;
        }
    




        internal void InsertPayCustomer( decimal pay,DateTime date,int idCast , string Sales_Man)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@pay", SqlDbType.Decimal);
            param[0].Value = pay;
            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@id_cast", SqlDbType.Int);
            param[2].Value = idCast;
            param[3] = new SqlParameter("@Sale_Man", SqlDbType.NVarChar,50);
            param[3].Value = idCast;
            da.excutequery("InsertPayCustomer", param);
            da.close();
        }


        internal DataTable SelectProdRuturnOrder(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectProdRuturnOrder", param);
            da.close();
            return dt;
        }

        internal DataTable SelectOrderReturn(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectOrderReturn", param);
            da.close();
            return dt;
        }

        internal void AddOrderReturn(int id_order, int Id_Cust , int id_pro,decimal Return_quantity, DateTime Return_date,
                                     decimal price , decimal amount , string Sales_Man )
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id_Order", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@Id_Cust", SqlDbType.Int);
            param[1].Value = Id_Cust;
            param[2] = new SqlParameter("@ID_Prou", SqlDbType.Int);
            param[2].Value = id_pro;
            param[3] = new SqlParameter("@quantity_Return", SqlDbType.Decimal);
            param[3].Value = Return_quantity;
            param[4] = new SqlParameter("@date_Return", SqlDbType.DateTime);
            param[4].Value =Return_date ;
            param[5] = new SqlParameter("@Price", SqlDbType.Decimal);
            param[5].Value = price;
            param[6] = new SqlParameter("@Amount", SqlDbType.Decimal);
            param[6].Value = amount;
            param[7] = new SqlParameter("@sales_Man", SqlDbType.NVarChar,50);
            param[7].Value = Sales_Man;
            da.excutequery("AddOrderReturn", param);
            da.close();

        }

        internal void UpdateOrderMoney(int id_order, decimal totalInvo, decimal pay, decimal rent)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@idOrder", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@totalInv", SqlDbType.Decimal);
            param[1].Value = totalInvo;
            param[2] = new SqlParameter("@pay", SqlDbType.Decimal);
            param[2].Value = pay;
            param[3] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[3].Value = rent;

            da.excutequery("UpdateMONEYOrder", param);
            da.close();


        }

        internal void UpdateOrderDetails(int id_order, int idProd, int quantity, decimal prise,  decimal discount, decimal amount, decimal totalAmount)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@id_prod", SqlDbType.Int);
            param[1].Value = idProd;
            param[2] = new SqlParameter("@quantity", SqlDbType.Int);
            param[2].Value = quantity;
            param[3] = new SqlParameter("@price", SqlDbType.Decimal);
            param[3].Value = prise;
            param[4] = new SqlParameter("@discount", SqlDbType.Decimal);
            param[4].Value = discount;
            param[5] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[5].Value = amount;
            param[6] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            param[6].Value = totalAmount;
            da.excutequery("UpdateOrderDetails", param);
            da.close();


        }


        internal DataTable SelectOrderMony()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectOrderMony", null);
            da.close();
            return dt;
        }


        internal DataTable SelectCustomerOrderMony(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("SelectCustomerOrderMony", param);
            da.close();
            return dt;
        }



        //internal void DeleteOrderMoney(int id)
        //{
        //    DataAccessLayer da = new DataAccessLayer();
        //    da.open();
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@id", SqlDbType.Int);
        //    param[0].Value = id;
        //    da.excutequery("DeleteOrderMoney", param);
        //    da.close();
        //}

        internal void UpdatePartOrder(int id_order, decimal rent)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;    
            param[1] = new SqlParameter("@rent", SqlDbType.Decimal);
            param[1].Value = rent;
            da.excutequery("UpdatePartOrder", param);
            da.close();
        }
        internal DataTable SelectSalesReb7foroneStore(int Id_Store)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Store", SqlDbType.Int);
            param[0].Value = Id_Store;
            dt = da.selected("SelectSalesReb7foroneStore", param);
            da.close();
            return dt;
        }
        internal DataTable SelectSalesReb7()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectSalesReb7", null);
            da.close();
            return dt;
        }
        internal DataTable Select_TotalpricOrderReturn(int id_order)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;
            dt = da.selected("Select_TotalpricOrderReturn", param);
            return dt;
        }





        internal DataTable VildateID_Order(int id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Order", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("VildateID_Order", param);
            da.close();
            return dt;
        }


        internal void AddReturnOrderUnUsed(int @id_order, int id_prod, int quantity, DateTime date,decimal Price,decimal Discount,decimal Amount ,decimal TotalAmount)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@id_prod", SqlDbType.Int);
            param[1].Value = id_prod;
            param[2] = new SqlParameter("@quantity", SqlDbType.Int);
            param[2].Value = quantity;
            param[3] = new SqlParameter("@date", SqlDbType.DateTime);
            param[3].Value = date;
            param[3] = new SqlParameter("@date", SqlDbType.DateTime);
            param[3].Value = date;
            param[4] = new SqlParameter("@Price", SqlDbType.Decimal);
            param[4].Value = Price;
            param[5] = new SqlParameter("@Discount", SqlDbType.Decimal);
            param[5].Value = Discount;
            param[6] = new SqlParameter("@Amount", SqlDbType.Decimal);
            param[6].Value = Amount;
            param[7] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            param[7].Value = TotalAmount;
            da.excutequery("AddReturnOrderUnUsed", param);
            da.close();


        }


        internal DataTable SelectValueReturnOrderUnUsed()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("SelectValueReturnOrderUnUsed", null);
            return dt;
        }
        internal DataTable DeleteReturnOrderUnUsed()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("DeleteReturnOrderUnUsed", null);
            return dt;
        }
        internal DataTable selectReturnOrderUnUsed(int id)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idorder", SqlDbType.Int);
            param[0].Value = id;
            dt = da.selected("selectReturnOrderUnUsed", param);
            da.close();
            return dt;
        }
        internal void UpdateProudectOrder(int idProd, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDProudect", SqlDbType.Int);
            param[0].Value = idProd;
            param[1] = new SqlParameter("@quntity", SqlDbType.Decimal);
            param[1].Value = Quantity;
            da.excutequery("UpdateProudectOrder", param);
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

        internal DataTable CountCusromerOrder()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("CountCusromerOrder", null);
            return dt;
        }

        internal DataTable SearchCountCusromerOrder(string id)
        {
            DataTable dt = new DataTable();

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,50);
            param[0].Value = id;

            dt = da.selected("SearchCountCusromerOrder", param);
            da.close();
            return dt;
        }
        internal DataTable Select_OldReturnOrder(int id_Order)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id_Order;
            dt = da.selected("Select_OldReturnOrder", param);
            da.close();
            return dt;
        }
        internal DataTable Report_OrderReturn()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            dt = da.selected("Report_OrderReturn", null);
            da.close();
            return dt;
        }
        internal DataTable Search_ReportOrderReturn(DateTime Date_From, DateTime Date_To)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = Date_From;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = Date_To;
       
            DataTable dt = new DataTable();
            dt = da.selected("Search_ReportOrderReturn", param);
            da.close();
            return dt;
        }
        internal DataTable RportOrder(int id_Order)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id_Order;
            dt = da.selected("RportOrder", param);
            da.close();
            return dt;
        }
        internal DataTable SelectQuantityOFProductFromOrderReturn(int id_Order, int ID_Product)
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IdOrder", SqlDbType.Int);
            param[0].Value = id_Order;
            param[1] = new SqlParameter("@ID_Product", SqlDbType.Int);
            param[1].Value = ID_Product;
            dt = da.selected("SelectQuantityOFProductFromOrderReturn", param);
            da.close();
            return dt;
        }
    }
}
