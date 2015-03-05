using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;

namespace ZumoSharp.Demo.Web.Controllers
{

	[Zumo.Sharp.AspNet.ZumoAuthorisationFilter]
    public class DemoController : ApiController
    {
        public IEnumerable<dynamic> Get()
        {
             var data = new List<dynamic>();
            // Print the fields for each customer.
			for(int i = 0; i< 10; i++)
            {
                dynamic item = new ExpandoObject();
                item.CustomerId = i;
				item.Name = "Mobile Services " + i;
                data.Add(item);
            }
            return data.ToArray();
        }
    }
}