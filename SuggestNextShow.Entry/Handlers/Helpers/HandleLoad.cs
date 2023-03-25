using CefSharp;
using CefSharp.OffScreen;

namespace SuggestNextShow.Entry.Handlers.Helpers
{
    /// <summary>
    /// Handler for browser to wait until frame or loading end
    /// </summary>
    public static class HandleLoad
    {
        /// <summary>
        /// Wait for the page to loading state change
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static async Task WaitForLoadingEnd(ChromiumWebBrowser browser)
        {
            var frameLoadTaskCompletionSource = new TaskCompletionSource<bool>();
            if (browser.IsLoading)
            {
                void LoadingStateChangeHandler(object sender, LoadingStateChangedEventArgs e)
                {
                    if (e.IsLoading == false)
                    {
                        frameLoadTaskCompletionSource.TrySetResult(true);
                        browser.LoadingStateChanged -= LoadingStateChangeHandler;
                    }
                }
                browser.LoadingStateChanged += LoadingStateChangeHandler;
                await frameLoadTaskCompletionSource.Task;
            }
            else
            {
                frameLoadTaskCompletionSource.TrySetResult(true);
            }
        }

        /// <summary>
        /// Wait for the page to finish frame load end
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static async Task WaitForFrameLoadEnd(ChromiumWebBrowser browser)
        {
            var frameLoadTaskCompletionSource = new TaskCompletionSource<bool>();
            void FrameLoadEndHandler(object sender, FrameLoadEndEventArgs e)
            {
                if (e.Frame.IsMain)
                {
                    frameLoadTaskCompletionSource.TrySetResult(true);
                    browser.FrameLoadEnd -= FrameLoadEndHandler;
                }
            }
            browser.FrameLoadEnd += FrameLoadEndHandler;
            await frameLoadTaskCompletionSource.Task;
        }
    }
}