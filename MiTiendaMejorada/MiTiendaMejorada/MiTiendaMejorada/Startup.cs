using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiTiendaMejorada.Startup))]
namespace MiTiendaMejorada
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
