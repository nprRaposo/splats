using Splats.Data.DAL;
using Splats.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splats.Services
{
	public class SeriesService
	{
		public static List<Serie> Get()
		{
			return SplatsDataAccess.GetSeries();
		}
		public static Serie GetBy(int id)
		{
			return SplatsDataAccess.GetSeries().FirstOrDefault(x => x.Id == id);
		}
		public static void Insert(Serie aSerie)
		{
			SplatsDataAccess.Insert(aSerie);
		}

		public static void Update(Serie aSerie)
		{
			SplatsDataAccess.Update(aSerie);
		}

		public static void Delete(int id)
		{
			SplatsDataAccess.Delete(id);
		}
	}
}
