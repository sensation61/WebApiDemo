using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api_demo.Controllers
{
    [RoutePrefix("api/tests")]
    public class TestController : ApiController
    {
        [Route()]
        public IEnumerable<string> Get()
        {
            return new string[] {
                "This is my controller response"
            };
        }

        [HttpGet]
        [Route("another")]
        [EnableCors(origins: "http://localhost:5986", headers: "*", methods: "*")]
        public IEnumerable<string> Another()
        {
            return new string[] {
            "This is a CORS response. ",
            "It works only from two origins: ",
            "1. www.bigfont.ca ",
            "2. the same origin."
        };
        }
    }
}
