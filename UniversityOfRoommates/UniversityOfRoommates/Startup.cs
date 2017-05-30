using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityOfRoommates.Startup))]
namespace UniversityOfRoommates
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
