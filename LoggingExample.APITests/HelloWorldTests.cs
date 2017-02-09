using LoggingExample.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LoggingExample.APITests
{
    [Trait("Category", "API")]
    public class HelloWorldTests
    {

        [Fact]
        public async Task HelloWorld_Get()
        {

            using (var serverAndClient = new HttpServerAndClient<Startup>())
            {

                var response = await serverAndClient.Client.GetAsync("api/hello");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var obj = (JObject)JsonConvert.DeserializeObject(content);

                Assert.Equal("hello world", obj["message"].ToString());


            }

        }


    }
}
