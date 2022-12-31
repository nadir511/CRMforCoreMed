using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StephenCoreMed.Startup))]

namespace StephenCoreMed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createRolesandUsers();
        }
    }
}
