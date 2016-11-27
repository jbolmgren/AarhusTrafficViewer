namespace API.NancyModules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Start.html"];
        }
    }
}