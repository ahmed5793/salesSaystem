using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace clothesStore.DAL
{
    class DataAccessLayer
    {
        SqlConnection con;
        internal DataAccessLayer()
        {

          //  con = new SqlConnection(@"Data Source = SQL5034.site4now.net; Initial Catalog = DB_A54A03_EasySystem; User Id = DB_A54A03_EasySystem_admin; Password = @TitoNasser1994; ");
           con = new SqlConnection(@"server =.; database=DB_A54A03_EasySystem;integrated security=true");

        }

        internal void open()
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                
            }

        }
        internal void close()
        {
            try {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        SqlCommand cm = new SqlCommand();
        internal DataTable selected(string storedProcedure,SqlParameter[]param)
        {
        
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = storedProcedure;
            cm.Connection = con;
            if (param!=null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cm.Parameters.Add(param[i]);
                }

            }
            SqlDataAdapter adabt = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            adabt.Fill(dt);
            return dt;
        }

        internal void excutequery (string storedProcedure,SqlParameter[]param)
        {
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = storedProcedure;
            cm.Connection = con;
            if (param!=null)
            {
                cm.Parameters.AddRange(param);
            }
            cm.ExecuteNonQuery();           
        }
    
    }
}
