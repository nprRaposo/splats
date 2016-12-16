using Splats.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Data.DAL
{
	public class SplatsDataAccess
	{
		public static List<Serie> GetSeries()
		{
			return SplatsContext.GetInstance().Series.ToList();
		}
	}
}
