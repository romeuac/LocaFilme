using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocaFilme.Startup))]
namespace LocaFilme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
