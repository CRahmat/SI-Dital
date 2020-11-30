using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SI_Dital.Startup))]
namespace SI_Dital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
