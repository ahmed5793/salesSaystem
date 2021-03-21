using clothesStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace clothesStore.Bl
{
    class Class
    {



          internal void addSuppliersDetails(int supDetalis, int IDProudect, int quantity,
            decimal prise,  decimal amount, decimal discount, decimal totalAmount)
        {

            DataAccessLayer da = new DataAccessLayer();


            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@supDetalis", SqlDbType.Int);
            param[0].Value = supDetalis;
            param[1] = new SqlParameter("@idProd", SqlDbType.Int);
            param[1].Value = IDProudect;
    
         
           
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
         

            da.excutequery("addSuppliersDetails", param);
            da.close();

        }



          internal void addSuppliersDetails(int SupID,DateTime date,string note,string salesMan)
        {

            DataAccessLayer da = new DataAccessLayer();


            da.open();
            SqlParameter[] param = new SqlParameter[4];
      
       
            param[0] = new SqlParameter("@SupID", SqlDbType.Int);
            param[0].Value = SupID;
            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@note", SqlDbType.NVarChar,350);
            param[2].Value = note;
       
     
            param[3] = new SqlParameter("@salesMan", SqlDbType.Decimal);
            param[3].Value = salesMan;

            da.excutequery("addSuppliersDetails", param);
            da.close();

        }
        

    }
}
