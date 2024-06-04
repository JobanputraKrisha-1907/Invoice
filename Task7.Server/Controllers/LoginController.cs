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
        public class LoginController : ControllerBase
        {
            Login LoginDAL = new Login();

            [HttpGet]
            public string DtToJson(DataTable dataTable)
            {
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dataTable);
                return JSONString;
            }


            [HttpPost]
            public ActionResult clientdata(parameter p)
            {
                dynamic Jdata = JObject.Parse(p.JSONData);
                DataTable dt = new DataTable();
                dt = LoginDAL.clientdata(Convert.ToString(Jdata.Email), Convert.ToString(Jdata.Password));
                string Sdt = DtToJson(dt);
                return Ok(new Response() { status = HttpStatusCode.OK, message = "Success", data = Sdt });
            }
        }
    }


