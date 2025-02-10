using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThietBiNhaBep_23TH0004.Startup))]
namespace ThietBiNhaBep_23TH0004
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
