using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Splats.Web.Controls.Combo.Models
{
	public class SplatsComboModel
	{
		public string ID { get; set; }
		public SelectList DataSource { get; set; }
		public bool SearchBox { get; set; }
		public IDictionary<string, object> HtmlAttributes { get; set; }

		public SplatsComboModel()
		{
			DataSource = new SelectList(Enumerable.Empty<SelectListItem>());
			SearchBox = true;
		}
	}
}