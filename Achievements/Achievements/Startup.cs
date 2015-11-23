using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Achievements.Startup))]
namespace Achievements
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
