using Splats.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Data.DAL
{
	public class SplatsContext : DbContext
	{
		private static SplatsContext _instance { get; set; }

		public SplatsContext() : base("Splats")
        {
		}

		public static SplatsContext GetInstance()
		{
			if (_instance == null)
				_instance = new SplatsContext();
			return _instance;
		}

		public DbSet<Serie> Series { get; set; }
		public List<Serie> GetSeries()
		{
			return Series.ToList();
		}


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
