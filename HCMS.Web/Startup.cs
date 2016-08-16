using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCMS.Web.Startup))]
namespace HCMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
