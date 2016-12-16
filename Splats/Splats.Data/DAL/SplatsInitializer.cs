using Splats.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Data.DAL
{
	public class SplatsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SplatsContext>
	{
		protected override void Seed(SplatsContext context)
		{
			var series = new List<Serie>
			{
				new Serie{Name="How I Met your Mother", Description="Ted telling his sons how i met their mother",Seasons = 9},
				new Serie{Name="Lost", Description="People lost in a paradise island",Seasons = 6},
				new Serie{Name="PrisonBreak", Description="A guy trying to rescue his brothers from jail",Seasons = 4}
			};

			context.SaveChanges();
		}
	}
}
