using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeItRain.Startup))]
namespace MakeItRain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
