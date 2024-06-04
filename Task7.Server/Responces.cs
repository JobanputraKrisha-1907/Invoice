using System.Net;

namespace Task_7.Server.DAL
{
    public class Response
    {
        public HttpStatusCode status { get; set; }

        public string message { get; set; }

        public object data { get; set; }
    }

    public class parameter
    {
        public string JSONData { get; set; }
    }

}

