using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Renta_de_Peliculas.Startup))]
namespace Renta_de_Peliculas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
