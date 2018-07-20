using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Skunkworks_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //private readonly SqlConnection conn = new SqlConnection("Data Source = LAT7490-6J7M0N2; Initial Catalog = test; Integrated Security = True");

        /* Overly complicated. Start using and searching .NET API documentation
        [HttpGet]
        public string complicated_formatTime() {
            int value = DateTime.Now.Month - 1;
            int fullMonth = 0;

            string[] months = {"January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December" };

            for (int i = 0; i < months.Length; i++)
            {
                if (value == i)
                {
                    fullMonth = i;
                }

            }
            string full_month = String.Format("The full month is {0}", months[fullMonth]);
            return full_month;
        }
        */
        
        // Refactored method to return date. Read and use .NET API documentation.
        [HttpGet]
        public string uncomplicated_formatTime()
        {
            DateTime time = DateTime.Now;
            string result = String.Format("It is currently the month of {0:MMMM}", time);
            return result;
        }
    
        
        
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
