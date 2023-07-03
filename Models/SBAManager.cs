using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Swachh_Bharat_Abhiyan_Project.Models
{
    public class SBAManager
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MG9C930V\SQLEXPRESS;Initial Catalog=SBA_DB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

        public bool InsertUpdateAndDelete(string command)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            if (ConnectionState.Closed == con.State)
            {

                con.Open();

            }

            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return true;
            else
                return false;
        }
        public DataTable GetAllRecord(string command)
        {
            SqlDataAdapter sa = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }
    }
}