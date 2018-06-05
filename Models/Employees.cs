using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SqliteFromScratch.Models
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class Employees
	{
		public int EmployeeId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Title { get; set; }
		public int ReportsTo { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime Hiredate { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
	}
}
