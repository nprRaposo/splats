using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Splats.Web.Startup))]
namespace Splats.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
