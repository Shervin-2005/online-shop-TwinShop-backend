using Shop.UI.Http;

namespace Shop.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var http = new HttpClient()
            {
                BaseAddress = new Uri(RouteConstants.BaseUrl)
            };
            var helper = new HttpClientHelper(http);

            Application.Run(new FormLogin(helper));

        }
    }
}