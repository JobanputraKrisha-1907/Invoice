using Google.Apis.AnalyticsReporting.v4.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using Task_7.Server.DAL;
using Task7.Server.DAL;

namespace Task7.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Product ProductDAL = new Product();

        [HttpGet]
        public string DtToJson(DataTable dataTable)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }

        [HttpGet]
        public ActionResult Productdata()
        {
            DataTable dt = new DataTable();
            dt = ProductDAL.productdata();
            string Sdt = DtToJson(dt);
            return Ok(new Response() { status = HttpStatusCode.OK, message = "Success", data = Sdt });
        }
    }
}

//[HttpPost]
//public ActionResult Productdata(parameter p)
//{
//    dynamic Jdata = JObject.Parse(p.JSONData);
//    DataTable dt = new DataTable();
//    dt = ProductDAL.productdata(Convert.ToString(Jdata.Name), Convert.ToString(Jdata.Description),
//         Convert.ToInt32(Jdata.price), Convert.ToString(Jdata.tax), Convert.ToString(Jdata.status));
//    string Sdt = DtToJson(dt);
//    return Ok(new Response() { status = HttpStatusCode.OK, message = "Success", data = Sdt });
//}

