using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThinkingSpace.Startup))]
namespace ThinkingSpace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
