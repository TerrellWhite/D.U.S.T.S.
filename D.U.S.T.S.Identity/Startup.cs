using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(D.U.S.T.S.Identity.Startup))]
namespace D.U.S.T.S.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
