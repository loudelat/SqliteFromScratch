using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqliteFromScratch.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqliteFromScratch.Controllers
{
    // MVS is handling the routing
    [Route("api/[Controller]")]
	public class CustomerController : Controller
    {
        [HttpGet]
        public List<Customers> GetData()
		{
			List<Customers> customers = new List<Customers>();

			string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

			using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                //sql is the tring that will be ruan as an sql command
                string sql = $"select * from customers limit 20;";

                // command combines the connection and the command string and creates the query
                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    //reader allows us to read each value that comes back and do something to it.
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Read returns true while there are more rows to advance to. then false when done.
                        while (reader.Read())
                        {
                            // map the data to our model
                            Customers newCustomer = new Customers()
                            {
                                CustomerId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Company = reader.GetValue(3).ToString(),
                                Address = reader.GetString(4),
                                City = reader.GetString(5),
                                State = reader.GetValue(6).ToString(),
                                Country = reader.GetString(7),
                                PostalCode = reader.GetValue(8).ToString(),
                                Phone = reader.GetValue(9).ToString(),
                                Fax = reader.GetValue(10).ToString(),
                                Email = reader.GetString(11),
                                SupportRepId = reader.GetInt32(12)
                            };


                            // add each one to the list
                            customers.Add(newCustomer);
                        }
                    }
                }

                conn.Close();
            }

            return customers;
        }       

	}
}

