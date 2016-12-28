using System.Web.Mvc;

namespace Splats.Web.Areas.Directors
{
    public class DirectorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Directors";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Director_default",
                "Directors/{controller}/{action}/{id}",
                new { controller = "Director", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}