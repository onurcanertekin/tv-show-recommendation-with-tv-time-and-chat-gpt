using CefSharp;
using CefSharp.OffScreen;
using SuggestNextShow.Entry.Handlers.Helpers;

namespace SuggestNextShow.Entry.Handlers
{
    /// <summary>
    /// Handle routing operations
    /// </summary>
    public static class HandleRouting
    {
        /// <summary>
        /// Route to Profile by clicking on navbar
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static async Task RouteToProfile(ChromiumWebBrowser browser)
        {
            //Click left navbar Profile button
            var topbarMenuButtonElement = await browser.EvaluateScriptAsync("document.querySelector('li[class=\"profile \"]').firstElementChild.click()");
            HandleConsole.AddStatus(topbarMenuButtonElement.Success, $"On Click Profile Button");

            await HandleLoad.WaitForFrameLoadEnd(browser);
        }
    }
}