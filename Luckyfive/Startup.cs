using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Luckyfive.Web.Startup))]
namespace Luckyfive.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
