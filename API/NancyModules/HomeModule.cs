namespace WebSite.NancyModules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => new StartModel("Are you talking to me?!");
        }
    }

    public class StartModel
    {
        public string Text { get; private set; }

        public StartModel(string text)
        {
            Text = text;
        }
    }
}