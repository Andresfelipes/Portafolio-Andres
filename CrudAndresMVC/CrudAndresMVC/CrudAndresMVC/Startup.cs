using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudAndresMVC.Startup))]
namespace CrudAndresMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
