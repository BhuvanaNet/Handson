using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo1.Startup))]
namespace demo1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
