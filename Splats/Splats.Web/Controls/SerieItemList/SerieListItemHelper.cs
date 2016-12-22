using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Splats.Web.Controls
{
	public static partial class HtmlHelperExtensions
	{

		public static MvcHtmlString SerieListItem(this HtmlHelper htmlHelper, string title, string description, string imageUrl)
		{
			return SerieListItem(htmlHelper, title, description, imageUrl, null);
		}

		public static MvcHtmlString SerieListItem(this HtmlHelper htmlHelper, string title, string description, string imageUrl, object htmlAttributes)
		{
			var model = new SerieListItemModel
			{
				Title = title,
				Description = description,
				ImageUrl = imageUrl,
				HtmlAttributes = htmlAttributes
			};

			return SerieListItem(htmlHelper, model);
		}

		public static MvcHtmlString SerieListItem(this HtmlHelper htmlHelper, SerieListItemModel model)
		{
			if (model.HtmlAttributes == null)
				model.HtmlAttributes = new RouteValueDictionary();

			model.HtmlAttributes = model.HtmlAttributes;

			return htmlHelper.Partial("~/Views/Controls/SerieListItem.cshtml", model);
		}
	}
}