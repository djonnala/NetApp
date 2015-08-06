using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetApp.Startup))]
namespace NetApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
