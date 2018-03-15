using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proVue.Startup))]
namespace proVue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
