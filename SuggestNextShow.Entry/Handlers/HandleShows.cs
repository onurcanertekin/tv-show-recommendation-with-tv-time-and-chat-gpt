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
        /// Get all shows as string list added by user
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        internal static async Task<List<string>> GetShowList(ChromiumWebBrowser browser)
        {
            List<string>? result = null;
            //Try get all shows added by user
            JavascriptResponse getAllShowsResult = await GetAllShows(browser);
            if (getAllShowsResult.Success && getAllShowsResult.Result is List<object>)
            {
                result = HandleLists.ObjectListToStringList(getAllShowsResult.Result as List<object>);
            }
            if (result is null)
            {
                HandleConsole.Exit(false, "Couldn't read show list");
            }
            return result as List<string>;
        }

        /// <summary>
        /// Get all shows added by user
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        private static async Task<JavascriptResponse> GetAllShows(ChromiumWebBrowser browser)
        {
            var getAllShows = await browser.EvaluateScriptAsync("Array.from(document.querySelector(\"[id=all-shows]\").querySelectorAll('li[class=\"first-loaded\"]')).map(x=>x.querySelector(\"h2\").textContent)");
            HandleConsole.AddStatus(getAllShows.Success, $"On Get All Shows Result");
            return getAllShows;
        }
    }
}