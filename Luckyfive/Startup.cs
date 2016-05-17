using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Luckyfive.Startup))]
namespace Luckyfive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
