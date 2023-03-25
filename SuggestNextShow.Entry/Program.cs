using CefSharp.OffScreen;
using StockBridge.Dto;
using StockBridge.Entry;
using StockBridge.Entry.Handlers.Helpers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Get configs
        SiteUriDto siteUri = ConfigManager.GetUri();
        HandleCefInitialize.InitializeCef();

        //Create Chromium instance with given uri
        using (var browser = new ChromiumWebBrowser(siteUri.SiteUri))
        {
            //Try to reach site
            var initialLoadResponse = await browser.WaitForInitialLoadAsync();
            if (initialLoadResponse.Success == false)
            {
                HandleConsole.Exit(false, "Couldn't reach to site");
            }
            HandleConsole.AddStatus(true, "Site initial load is successfull");
        }

        HandleConsole.Exit(true, "Succesfull");
    }
}