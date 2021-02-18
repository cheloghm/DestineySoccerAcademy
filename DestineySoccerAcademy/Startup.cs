using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DestineySoccerAcademy.Startup))]
namespace DestineySoccerAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
