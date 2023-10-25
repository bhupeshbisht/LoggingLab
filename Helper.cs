using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class Helper
    {
        public static bool InsertLogData(string conString,string tableName,string logContent)
        {
            bool flag=false;
            string query = "insert into "+tableName+" (logs) value ('"+ logContent + "')";
            SqlConnection con = new SqlConnection(conString);
            try
            {               
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int i=cmd.ExecuteNonQuery();
                if(i>0)
                    flag=true;

            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                con.Close();
            }
            return flag;
        }
    }
}
