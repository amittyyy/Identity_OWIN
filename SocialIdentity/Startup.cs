using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialIdentity.Startup))]
namespace SocialIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
