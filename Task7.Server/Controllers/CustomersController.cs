using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;

using Task_7.Server.DAL;

namespace Task7.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
      Customer customerDAL = new  Customer();
       
        [HttpGet]
        public string DtToJson(DataTable dataTable)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }

        [HttpGet]
        public ActionResult Customerdata()
        {
   
            DataTable dt = new DataTable();
            dt = customerDAL.customerdata();
            string Sdt = DtToJson(dt);
            return Ok(new Response() { status = HttpStatusCode.OK, message = "Success", data = Sdt });

        }
    }
}
