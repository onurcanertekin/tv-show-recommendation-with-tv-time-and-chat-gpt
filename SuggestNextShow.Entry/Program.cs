﻿using CefSharp.OffScreen;
using SuggestNextShow.Dto;
using SuggestNextShow.Entry;
using SuggestNextShow.Entry.Handlers;
using SuggestNextShow.Entry.Handlers.Helpers;

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

            //Handle login with credentials,
            //NOTE: Do not forget to configure app.config files username and password sections
            HandleLogin.SetCredentials(ConfigManager.GetCredentials());
            await HandleLogin.LoginToSite(browser);
        }

        HandleConsole.Exit(true, "Succesfull");
    }
}