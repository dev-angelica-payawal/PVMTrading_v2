using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PVMTrading_v1.Startup))]
namespace PVMTrading_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);



        }

       
    }
}
