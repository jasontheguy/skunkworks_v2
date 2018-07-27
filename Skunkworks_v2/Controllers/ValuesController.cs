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
        public string Get(int id)
        {
            SqlCommand get_row = new SqlCommand("SELECT * FROM dbo.students WHERE _id = @id", conn);
            get_row.Parameters.AddWithValue("@id", id);
            string res = "";
            conn.Open();
            using (var reader = get_row.ExecuteReader())
            {
                reader.Read();
                res = reader.GetString(0);
                return res;

            }
            
        }
        // POST api/values
        [HttpPost]
        public void Post()
        {
            conn.Open();    
            string post_query = "INSERT INTO dbo.students(FirstName, LastName, Age, Grade) VALUES(@FirstName, @LastName, @Age, @Grade)";
            SqlCommand exec = new SqlCommand(post_query, conn);
            
            exec.Parameters.AddWithValue("@FirstName", "Randy");
            exec.Parameters.AddWithValue("@LastName", "Dingle");
            exec.Parameters.AddWithValue("@Age", 15);
            exec.Parameters.AddWithValue("@Grade", 10);
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
            int ID = id;
            string del_query = "DELETE FROM dbo.students WHERE _id = @id";
            conn.Open();
            SqlCommand exec = new SqlCommand(del_query, conn);
            exec.Parameters.AddWithValue("@id", ID);
            exec.BeginExecuteNonQuery();
            conn.Close();

        }
    }
}
