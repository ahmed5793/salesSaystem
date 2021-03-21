using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using clothesStore.DAL;
using DevExpress.XtraEditors.Filtering.Templates;

namespace clothesStore.Bl
{
     class Proudect
    {
        internal void addproudect(String name,int ID_Category, decimal Quantity,decimal Sales_Price,
                                  decimal Purshasing_Price,decimal minimun,string color,int Barcode)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Name_Prod", SqlDbType.NVarChar,150);
            param[0].Value = name;
            param[1] = new SqlParameter("@Id_Category", SqlDbType.Int);
            param[1].Value = ID_Category;
     
            param[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[2].Value = Quantity;
            param[3] = new SqlParameter("@Sales_price", SqlDbType.Decimal);
            param[3].Value = Sales_Price;
            param[4] = new SqlParameter("@Buy_Price", SqlDbType.Decimal);
            param[4].Value = Purshasing_Price;
            param[5] = new SqlParameter("@minimum", SqlDbType.Decimal);
            param[5].Value = minimun;
            param[6] = new SqlParameter("@Color", SqlDbType.NVarChar,50);
            param[6].Value = color;
            param[7] = new SqlParameter("@Barcode", SqlDbType.BigInt);
            param[7].Value = Barcode;
            da.excutequery("Addproudect", param);
            da.close();

        }
        public DataTable selectProudect()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("selectProudect", null);
            da.close();
            return ds;
        }
        public DataTable Last_IdProd()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("Last_IdProd",null);
            da.close();
            return ds;
        }
        public DataTable Select_ProductFromStore(int ID_Product)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            DataTable ds = new DataTable();
            ds = da.selected("Select_ProductFromStore", param);
            da.close();
            return ds;
        }
        public DataTable selectListProudect( int ID_Product )
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Prodcut", SqlDbType.Int);
            param[0].Value = ID_Product;
            DataTable ds = new DataTable();
            ds = da.selected("selectListProudect", param);
            da.close();
            return ds;
        }
        public DataTable Select_ProductFormStoreForSale()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();         
            DataTable ds = new DataTable();
            ds = da.selected("Select_ProductFormStoreForSale", null);
            da.close();
            return ds;
        }
        public DataTable Validate_ProductFormStoreForSale(int ID_Product)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            DataTable ds = new DataTable();
            ds = da.selected("Validate_ProductFormStoreForSale", param);
            da.close();
            return ds;
        }
        internal DataTable search(string ID , int ID_Store)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar,100);
            param[0].Value = ID;
            param[1] = new SqlParameter("@ID_Store", SqlDbType.Int);
            param[1].Value = ID_Store;
            DataTable dt = new DataTable();
            dt = da.selected("search", param);
            da.close();
            return dt;
        }
        internal DataTable searchForProduct(string ID)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 100);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("searchForProduct", param);
            da.close();
            return dt;
        }

        internal void deleteProudect(int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            da.excutequery("deleteProudect", param);
            da.close();
        }
        internal void Updateproudect(int Id_Prod ,String name, int ID_Category, decimal Sales_Price, decimal Buy_Price,
                                     decimal Minimum,string Color,int Barcode  )
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@id_Prod", SqlDbType.Int);
            param[0].Value = Id_Prod;
            param[1] = new SqlParameter("@Name_Prod", SqlDbType.NVarChar,150);
            param[1].Value = name;
            param[2] = new SqlParameter("@Id_Category", SqlDbType.Int);
            param[2].Value = ID_Category;
            param[3] = new SqlParameter("@Sales_price", SqlDbType.Decimal);
            param[3].Value = Sales_Price;
            param[4] = new SqlParameter("@Buy_Price", SqlDbType.Decimal);
            param[4].Value = Buy_Price;
            param[5] = new SqlParameter("@minimum", SqlDbType.Decimal);
            param[5].Value = Minimum;
            param[6] = new SqlParameter("@Color", SqlDbType.NVarChar,50);
            param[6].Value = Color;
            param[7] = new SqlParameter("@Barcode", SqlDbType.BigInt);
            param[7].Value = Barcode;
           
            da.excutequery("UpdateProudect", param);
            da.close();
        }
        internal DataTable Vaidladate(string name, string category,string color)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 100);
            param[0].Value = name;
            param[1] = new SqlParameter("@category", SqlDbType.NVarChar, 50);
            param[1].Value = category;
            param[2] = new SqlParameter("@color", SqlDbType.NVarChar, 50);
            param[2].Value = color;       
            DataTable dt = new DataTable();
            dt = da.selected("Vaidladate", param);
            da.close();
            return dt;
        }


        internal DataTable SearchSuppliers(string ID)
        {

            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 100);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("SearchSuppliers", param);
            da.close();
            return dt;

        }
        internal void Update_TotalProduct()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            da.excutequery("Update_TotalProduct", null);
            da.close();
        }
        internal DataTable PrintAllProudects ()
        {
            DataAccessLayer da = new DataAccessLayer();
            
            DataTable dt = new DataTable();
            dt = da.selected("PrintAllProudects", null);
            da.close();
            return dt;
        }

        internal DataTable SearchMovePorduct(DateTime Date_From , DateTime Date_To)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date_From", SqlDbType.DateTime);
            param[0].Value = Date_From;
            param[1] = new SqlParameter("@Date_To", SqlDbType.DateTime);
            param[1].Value = Date_To;
            DataTable dt = new DataTable();
            dt = da.selected("SearchMovePorduct", param);
            da.close();
            return dt;
        }
        public DataTable SelectMovePorduct()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("SelectMovePorduct", null);
            da.close();
            return ds;
        }

        public DataTable select_ComboProduct()
        {

            DataAccessLayer da = new DataAccessLayer();

            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("select_ComboProduct", null);

            da.close();
            return ds;

        }

        public DataTable selectLastBarcode()
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("selectLastBarcode", null);
            da.close();
            return ds;

        }

        internal void add_randomBarcode(int barcode)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@barcode", SqlDbType.BigInt);
            param[0].Value = barcode;
            da.excutequery("add_randomBarcode", param);
            da.close();
        }

        internal DataTable Select_itemBarCode(int ID)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("Select_itemBarCode", param);

            da.close();
            return dt;

        }

        internal void Update_Barcode(int barcode)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Barcode", SqlDbType.BigInt);
            param[0].Value = barcode;
            da.excutequery("Update_Barcode", param);
            da.close();
        }
        internal DataTable search_barcode(Int64 Barcode)
        {


            DataAccessLayer da = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@barcode", SqlDbType.BigInt);
            param[0].Value = Barcode;
            DataTable dt = new DataTable();
            dt = da.selected("search_barcode", param);

            da.close();
            return dt;

        }

        internal DataTable search_barcodemoshtryat(string ID)
        {


            DataAccessLayer da = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@barcode", SqlDbType.NVarChar, 250);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("search_barcodemoshtryat", param);
            da.close();
            return dt;

        }
        internal DataTable VildateBarcode(string ID)
        {


            DataAccessLayer da = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@barcode", SqlDbType.NVarChar, 250);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("VildateBarcode", param);
            da.close();
            return dt;

        }
        internal DataTable VildateUpdateBarcode(int id,string barcode)
        {


            DataAccessLayer da = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@idprod", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@barcode", SqlDbType.NVarChar, 250);
            param[1].Value = barcode;
            DataTable dt = new DataTable();
            dt = da.selected("VildateUpdateBarcode", param);
            da.close();
            return dt;

        }
        internal DataTable Search_AllProudects(string id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,100);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = da.selected("Search_AllProudects", param);
            da.close();
            return dt;
        }
        internal DataTable vaildateQuantity(int idProudect,int quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@idProudect", SqlDbType.Int);
            param[0].Value = idProudect;
            param[1] = new SqlParameter("@quantity", SqlDbType.Int);
            param[1].Value = quantity;
            DataTable dt = new DataTable();
            dt = da.selected("vaildateQuantity", param);

            da.close();
            return dt;

        }
        internal DataTable SelectQuantityMinmun(int idProd )
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idProd", SqlDbType.Int);
            param[0].Value = idProd;
            dt = da.selected("SelectQuantityMinmun", param);
            da.close();
            return dt;
        }

        internal DataTable searchForProductBarcode(string id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar);
            param[0].Value = id;





            DataTable dt = new DataTable();
            dt = da.selected("searchForProductBarcode", param);
            da.close();
            return dt;
        }

        internal DataTable SearchSelectMinmun(string ID)
        {


            DataAccessLayer da = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("SearchSelectMinmun", param);

            da.close();
            return dt;

        }
        public DataTable SelectMinmun()
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("SelectMinmun", null);
            da.close();
            return ds;
        }
        internal DataTable Select_UnitProduct(int ID)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = da.selected("Select_UnitProduct", param);
            da.close();
            return dt;
        }
        internal DataTable Select_PriceUnitProduct(int ID_Product , int Id_Unit )
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            param[1] = new SqlParameter("@Id_Unit", SqlDbType.Int);
            param[1].Value = Id_Unit;
            dt = da.selected("Select_PriceUnitProduct", param);
            da.close();
            return dt;
        }
        internal DataTable Select_NumberSmallInLargeUnit(int ID_Product , string Unit_Name )
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            param[1] = new SqlParameter("@Unit_name", SqlDbType.NVarChar,50);
            param[1].Value = Unit_Name;
            DataTable dt = new DataTable();
            dt = da.selected("Select_NumberSmallInLargeUnit", param);
            da.close();
            return dt;
        }
    
        internal void Update_ProductQuantityDecrease(int Id_Prod, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Prod;           
            param[1] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[1].Value = Quantity;
            da.excutequery("Update_ProductQuantityDecrease", param);
            da.close();
        }
        internal void Update_ProductQuantityIncrease(int Id_Prod ,decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Prod;
      
            param[1] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[1].Value = Quantity;
            da.excutequery("Update_ProductQuantityIncrease", param);
            da.close();
        }
        internal void Update_StoreProductQuantitySmallUnit(int Id_Prod, int Id_Store, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Prod;
            param[1] = new SqlParameter("@ID_Store", SqlDbType.Int);
            param[1].Value = Id_Store;
            param[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[2].Value = Quantity;
            da.excutequery("Update_StoreProductQuantitySmallUnit", param);
            da.close();
        }
        public DataTable Select_LastIdTranfair()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("Select_LastIdTranfair", null);
            da.close();
            return ds;
        }
        internal void Add_TranfairProductInformation( int Id_StoreFrom,string From_StoreName ,int Id_StoreTo, 
                                                   string To_StoreName,string Sales_man ,DateTime Date_Transfair,string  note)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];           
            param[0] = new SqlParameter("@Id_StoreFrom", SqlDbType.Int);
            param[0].Value = Id_StoreFrom;
            param[1] = new SqlParameter("@From_StoreNAme", SqlDbType.NVarChar,50);
            param[1].Value = From_StoreName;
            param[2] = new SqlParameter("@Id_StoreTo", SqlDbType.Int);
            param[2].Value = Id_StoreTo;
            param[3] = new SqlParameter("@To_StoreNAme", SqlDbType.NVarChar,50);
            param[3].Value = To_StoreName;
            param[4] = new SqlParameter("@Sales_man", SqlDbType.NVarChar,50);
            param[4].Value = Sales_man;
            param[5] = new SqlParameter("@date_Transfair", SqlDbType.DateTime);
            param[5].Value = Date_Transfair;
            param[6] = new SqlParameter("@note", SqlDbType.NVarChar,250);
            param[6].Value = note;
            da.excutequery("Add_TranfairProductInformation", param);
            da.close();
        }
        internal void Add_TRansfairProductDetails(int Id_Transfair, int Id_Product,string Unit, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Id_Transfair", SqlDbType.Int);
            param[0].Value = Id_Transfair;
            param[1] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[1].Value = Id_Product;
            param[2] = new SqlParameter("@unit_name", SqlDbType.NVarChar,50);
            param[2].Value = Unit;
            param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[3].Value = Quantity;
            da.excutequery("Add_TRansfairProductDetails", param);
            da.close();
        }
        internal void Add_BalanceAdjustment(int Id_Product, decimal Quantity, DateTime Date,
                                                  string Note, string Sales_man,  string Status)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.Int);
            param[0].Value = Id_Product;     
            param[1] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[1].Value = Quantity;
            param[2] = new SqlParameter("@date", SqlDbType.DateTime);
            param[2].Value = Date;
            param[3] = new SqlParameter("@note", SqlDbType.NVarChar, 250);
            param[3].Value = Note;
            param[4] = new SqlParameter("@Sales_man", SqlDbType.NVarChar,50);
            param[4].Value = Sales_man;
            param[5] = new SqlParameter("@Status", SqlDbType.NVarChar, 250);
            param[5].Value = Status;
            da.excutequery("Add_BalanceAdjustment", param);
            da.close();
        }
        public DataTable Report_ProductTransfair()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("Report_ProductTransfair", null);
            da.close();
            return ds;
        }
        internal DataTable SearchReport_ProductTransfair(DateTime Date_From, DateTime Date_To)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = Date_From;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = Date_To;
            DataTable dt = new DataTable();
            dt = da.selected("SearchReport_ProductTransfair", param);
            da.close();
            return dt;
        }
        public DataTable Report_AdjustmentBalanceProduct()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable ds = new DataTable();
            ds = da.selected("Report_AdjustmentBalanceProduct", null);
            da.close();
            return ds;
        }
        internal DataTable SearchReport_AdjustmentBalanceProduct(DateTime Date_From, DateTime Date_To)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DateFrom", SqlDbType.Date);
            param[0].Value = Date_From;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value = Date_To;
            DataTable dt = new DataTable();
            dt = da.selected("SearchReport_AdjustmentBalanceProduct", param);
            da.close();
            return dt;
        }

    }
}

