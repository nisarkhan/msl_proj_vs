using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSL.Startup))]
namespace MSL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
