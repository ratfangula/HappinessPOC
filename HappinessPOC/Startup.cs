using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HappinessPOC.Startup))]
namespace HappinessPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
