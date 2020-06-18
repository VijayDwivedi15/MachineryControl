using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JainMachinery.Startup))]
namespace JainMachinery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
