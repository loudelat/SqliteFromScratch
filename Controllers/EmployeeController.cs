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
    [Route("api/[Controller]")]
	public class EmployeeController : Controller
    {
		[HttpGet]
		public List<Employees> GetData()
		{
			List<Employees> employees = new List<Employees>();

			string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

			using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                //sql is the tring that will be ruan as an sql command
				string sql = $"select * from employees where HireDate < '2003-01-01';";

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
                            Employees newEmployee = new Employees()
                            {
                                EmployeeId = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Title = reader.GetString(3),
                                ReportsTo = reader.GetInt32(4),
                                BirthDate = reader.GetDateTime(5),
                                Hiredate = reader.GetDateTime(6),
                                Address = reader.GetString(7),
                                City = reader.GetString(8),
                                State = reader.GetString(9),
                                Country = reader.GetString(10),
                                PostalCode = reader.GetString(11),
                                Phone = reader.GetString(12),
                                Fax = reader.GetString(13),
                                Email = reader.GetString(14)
                            };


                            // add each one to the list
                            employees.Add(newEmployee);
                        }
                    }
                }

                conn.Close();
            }

            return employees;

		}
    }
}
