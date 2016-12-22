using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Splats.Web.Controls
{
	public static partial class HtmlHelperExtensions
	{
		
		public static MvcHtmlString SplatsCombo(this HtmlHelper htmlHelper, string name, SelectList selectList)
		{
			return SplatsCombo(htmlHelper, name, selectList, null);
		}

		public static MvcHtmlString SplatsCombo(this HtmlHelper htmlHelper, string name, SelectList selectList, object htmlAttributes)
		{
			var model = new SplatsComboModel
			{
				ID = name,
				DataSource = selectList,
				HtmlAttributes = htmlAttributes,
				SearchBox = true
			};

			return SplatsCombo(htmlHelper, model);
		}

		public static MvcHtmlString SplatsCombo(this HtmlHelper htmlHelper, SplatsComboModel model)
		{
			if (model.HtmlAttributes == null)
				model.HtmlAttributes = new RouteValueDictionary();

			model.HtmlAttributes = model.HtmlAttributes;

			return htmlHelper.Partial("~/Views/Controls/Combo.cshtml", model);
		}
	}
}