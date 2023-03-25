using CefSharp.OffScreen;
using SuggestNextShow.Dto;

namespace SuggestNextShow.Entry.Handlers
{
    /// <summary>
    /// Handle login operations
    /// </summary>
    public static class HandleLogin
    {
        private static CredentialsDto _credentials;

        public static void SetCredentials(CredentialsDto credentialsDto)
        {
            _credentials = credentialsDto;
        }

        /// <summary>
        /// login to site step by step using credentials readed from config.
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static async Task LoginToSite(ChromiumWebBrowser browser)
        {
        }
    }
}