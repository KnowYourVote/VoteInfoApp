using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowYourVote.Startup))]
namespace KnowYourVote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
