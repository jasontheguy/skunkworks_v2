using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Skunkworks_v2.Models;
namespace Skunkworks_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly SqlConnection conn = new SqlConnection("Data Source = lat7490-6j7m0n2; Initial Catalog = Test; Integrated Security = True");

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
        public void Post()
        {
            conn.Open();    
            string post_query = "INSERT INTO dbo.students(_id,FirstName, LastName, Age, Grade, Teacher) VALUES(@ID ,@FirstName, @LastName, @Age, @Grade,@Teacher)";
            SqlCommand exec = new SqlCommand(post_query, conn);
            exec.Parameters.AddWithValue("@ID", 1);
            exec.Parameters.AddWithValue("@FirstName", "James");
            exec.Parameters.AddWithValue("@LastName", "Dingle");
            exec.Parameters.AddWithValue("@Age", 15);
            exec.Parameters.AddWithValue("@Grade", 10);
            exec.Parameters.AddWithValue("@Teacher", "Jessica Apple");
            exec.BeginExecuteNonQuery();
            conn.Close();
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
