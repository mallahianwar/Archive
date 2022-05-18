using Archive.Models.Classes;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Archive.Startup))]
namespace Archive
{
    public partial class Startup
    {
        [System.Obsolete]
        public void Configuration(IAppBuilder app)
        {
            MasterCls.initProg();
            ConfigureAuth(app);
        }
    }
}
