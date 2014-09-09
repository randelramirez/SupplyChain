using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupplyChain.Web.Startup))]
namespace SupplyChain.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
