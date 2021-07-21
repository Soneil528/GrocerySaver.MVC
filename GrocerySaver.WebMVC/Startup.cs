using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrocerySaver.WebMVC.Startup))]
namespace GrocerySaver.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
