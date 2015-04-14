using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NuevoStaj.Startup))]
namespace NuevoStaj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
