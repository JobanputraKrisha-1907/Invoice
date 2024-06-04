using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net;
using Task_7.Server.DAL;

namespace Task_7.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class InvoiceController : Controller
    {

        [HttpPost]
        public ActionResult InsertInvoice(parameter p)
        {

            dynamic Jdata = JObject.Parse(p.JSONData);
            DataTable dt = new DataTable();
            string billTo = Jdata.BillTo;
            DateTime invoiceDate = Jdata.InvoiceDate;
            string product = Jdata.productlist[0].productName;
           
            string invoiceNote = Jdata.invoicenote;
            int subtotal = Jdata.subTotal;
            int totalTax = Jdata.totaltax;
            int grandTotal = Jdata.Grandtotal;


            InvoiceDAL dal = new InvoiceDAL();
            bool success = dal.InsertInvoice(billTo, invoiceDate, product, invoiceNote, subtotal, totalTax, grandTotal);

            if (success)
            {
                return Json(new { status = "success", message = "Invoice inserted successfully" });
            }
            else
            {
                return Json(new { status = "error", message = "Failed to insert invoice" });
            }
           
        }
    }

}