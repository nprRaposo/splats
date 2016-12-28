using System.Web.Mvc;

namespace Splats.Web.Areas.Serie
{
    public class SerieAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Serie";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
			context.MapRoute(
				"Serie_default",
				"Serie/{controller}/{action}/{id}",
				new { controller = "Series", action = "Index", id = UrlParameter.Optional }
			);
        }
    }
}