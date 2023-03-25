using CefSharp;
using CefSharp.OffScreen;
using SuggestNextShow.Entry.Handlers.Helpers;

namespace SuggestNextShow.Entry.Handlers
{
    /// <summary>
    /// Handle operations releated to shows
    /// </summary>
    public static class HandleShows
    {
        /// <summary>
        /// Get all shows added by user
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static async Task<JavascriptResponse> GetAllShows(ChromiumWebBrowser browser)
        {
            var getAllShows = await browser.EvaluateScriptAsync("Array.from(document.querySelector(\"[id=all-shows]\").querySelectorAll('li[class=\"first-loaded\"]')).map(x=>x.querySelector(\"h2\").textContent)");
            HandleConsole.AddStatus(getAllShows.Success, $"On Get All Shows Result");
            return getAllShows;
        }
    }
}