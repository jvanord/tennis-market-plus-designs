using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tennis_market_plus_designs.Startup))]
namespace tennis_market_plus_designs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
