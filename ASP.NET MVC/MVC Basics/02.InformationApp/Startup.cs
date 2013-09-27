using Owin;

namespace _02.InformationApp
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
