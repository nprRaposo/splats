using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Data.Entities
{
	public class Director
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public virtual IEnumerable<Serie> Series { get; set; }

		[NotMapped]
		public string FullName { get { return this.Name + " " + this.Surname; } }
	}
}


