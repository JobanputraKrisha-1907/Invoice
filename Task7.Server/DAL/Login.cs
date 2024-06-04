using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Task_7.Server.DAL
{
    public class Login : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;" +
            "Initial Catalog=Task_fundbazar;Integrated Security=false");

        public DataTable clientdata(string Email, string Password)
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "clientdatainsert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@password", Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}




