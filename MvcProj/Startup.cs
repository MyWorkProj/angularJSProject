using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProj.Startup))]
namespace MvcProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
