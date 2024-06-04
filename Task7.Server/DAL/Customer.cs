using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Task_7.Server.DAL
{
    public class Customer : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;" +
            "Initial Catalog=Task_fundbazar;Integrated Security=false");

        public DataTable customerdata()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "customers";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        
        
    }
}










