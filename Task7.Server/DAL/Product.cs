using System.Data;
using System.Data.SqlClient;

namespace Task7.Server.DAL
{
    public class Product
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local; Initial Catalog=Task_fundbazar;" +
            "Integrated Security=false");

       
        public DataTable productdata()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "productdetail";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
