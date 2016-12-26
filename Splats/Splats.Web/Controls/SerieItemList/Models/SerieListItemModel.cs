using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Splats.Web.Controls
{
	public class SerieListItemModel
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public object HtmlAttributes { get; set; }

		public string DivContainerId
		{
			get { return "divSerie" + this.Id; }
		}

	}
}