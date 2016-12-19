using Splats.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Data.DAL
{
	public class SplatsDataAccess
	{

		#region Properties
		private static SplatsContext db { get { return SplatsContext.GetInstance(); } } 
		#endregion

		public static List<Serie> GetSeries()
		{
			return db.Series.ToList();
		}

		public static void Insert(Serie aSerie)
		{
			db.Series.Add(aSerie);
			db.SaveChanges();
		}

		public static void Update(Serie aSerie)
		{
			var entity = db.Series.Find(aSerie.Id);

			if (entity == null)
			{
				return;
			}

			db.Entry(entity).CurrentValues.SetValues(aSerie);
		}

		public static void Delete(int id)
		{
			var serie = db.Series.Find(id);
			db.Series.Remove(serie);
			db.SaveChanges();
		}
	}
}
