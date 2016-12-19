using System;
using System.Collections.Generic;
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
	}
}


