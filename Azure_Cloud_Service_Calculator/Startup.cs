using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Azure_Cloud_Service_Calculator.Startup))]
namespace Azure_Cloud_Service_Calculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
