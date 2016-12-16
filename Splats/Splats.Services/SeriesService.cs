using Splats.Data.DAL;
using Splats.Data.Entities;
using System.Collections.Generic;

namespace Splats.Services
{
	public class SeriesService
	{
		public static List<Serie> Get()
		{
			return SplatsDataAccess.GetSeries();
		}

	}
}
