using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LoggingExample.API.Controllers
{
    [RoutePrefix("api/hello")]
    public class HelloController : ApiController
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Route("")]
        public async Task<object> Get()
        {

            Log.Debug("api/hello GET Request traced");

            return new
            {
                Message = "hello world"
            };
        }

    }
}
