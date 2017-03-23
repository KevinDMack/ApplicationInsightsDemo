using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationInsightsDemo.Startup))]
namespace ApplicationInsightsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
