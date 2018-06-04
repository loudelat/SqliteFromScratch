using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SqliteFromScratch.Models
{
    
    public class Track
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int? AlbumId { get; set; }
		public int MediaTypeId { get; set; }
		public int? GenreId { get; set; }
		public string Composer { get; set; }
		public int Milliseconds { get; set; }
		public int? Bytes { get; set; }
		public int UnitPrice { get; set; }

    }

    
}
