using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BandManager.Startup))]
namespace BandManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
