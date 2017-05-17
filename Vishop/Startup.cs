using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vishop.Startup))]
namespace Vishop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
