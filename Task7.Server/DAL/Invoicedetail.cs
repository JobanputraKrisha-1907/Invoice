using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class InvoiceDAL
{
    // Connection string
    private string connectionString = "Data Source=(localdb)\\Local; Initial Catalog=Task_fundbazar; Integrated Security=false";
    public bool InsertInvoice(string billTo, DateTime invoiceDate, string product, string invoiceNote, int subtotal, int totalTax, 
        int grandTotal)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("InsertInvoice", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@billto", billTo);
                command.Parameters.AddWithValue("@invoicedate", invoiceDate);
                command.Parameters.AddWithValue("@product", product);
                command.Parameters.AddWithValue("@invoicenote", invoiceNote);
                command.Parameters.AddWithValue("@subtotal", subtotal);
                command.Parameters.AddWithValue("@totaltax", totalTax);
                command.Parameters.AddWithValue("@grandtotal", grandTotal);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
            }
        }
    }
}
