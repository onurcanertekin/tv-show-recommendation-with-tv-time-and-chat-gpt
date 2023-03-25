using CefSharp;
using CefSharp.OffScreen;
using SuggestNextShow.Dto;
using SuggestNextShow.Entry.Handlers.Helpers;

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
            //Click top right Login button
            var topbarMenuButtonElement = await browser.EvaluateScriptAsync("document.querySelector('a[class=\"views__NavLink-sc-1tygrp6-1 iLlEYj\"]').click()");
            HandleConsole.AddStatus(topbarMenuButtonElement.Success, $"On Click Login Button");

            //Input user credentials to opened popup
            var addUsernameCredentialToElement = await browser.EvaluateScriptAsync($"document.querySelector('input[name=\"username\"]').value='{_credentials.Username}'");
            HandleConsole.AddStatus(addUsernameCredentialToElement.Success, $"On Add Username to Email Input");
            var addPasswordCredentialToElement = await browser.EvaluateScriptAsync($"document.querySelector('input[name=\"password\"]').value='{_credentials.Password}'");
            HandleConsole.AddStatus(addPasswordCredentialToElement.Success, $"On Add Password to Email Input");

            //Click Login button in modal
            var loginButtonInModal = await browser.EvaluateScriptAsync("document.querySelector('input[value=\"Login\"]').click()");
            HandleConsole.AddStatus(loginButtonInModal.Success, $"On Click Login Button");

            //Wait for login
            await HandleLoad.WaitForLoadingEnd(browser);
            bool loginCheck = await CheckIfLoginHasError(browser);
            if (loginCheck == false)
            {
                HandleConsole.Exit(false, "Error on login");
            }
            await HandleLoad.WaitForFrameLoadEnd(browser);

            HandleConsole.AddStatus(true, $"Logged in succesfully");
        }

        private static async Task<bool> CheckIfLoginHasError(ChromiumWebBrowser browser)
        {
            bool result = true;
            //Check if already succesfully logged in
            var checkAlreadyLoggedIn = await browser.EvaluateScriptAsync($"(function() {{ try {{\r\n  return document.querySelector('input[name=\"username\"]').value\r\n}} catch (err) {{\r\n    return \"\";}} }})();");
            if (checkAlreadyLoggedIn.Success != false && string.IsNullOrWhiteSpace(checkAlreadyLoggedIn.Result as string) != false)
            {
                return true;
            }

            //Check if username input has any error
            var checkUsernameError = await browser.EvaluateScriptAsync($"document.querySelector('input[name=\"username\"]').nextSibling.textContent");
            if (checkUsernameError.Success == false || string.IsNullOrWhiteSpace(checkUsernameError.Result as string) == false)
            {
                result = false;
                HandleConsole.AddStatus(false, $"Result: {checkUsernameError.Result}");
            }
            else
            {
                HandleConsole.AddStatus(true, "Username has no error");
            }

            //Check if password input has any error
            var checkPasswordError = await browser.EvaluateScriptAsync($"document.querySelector('input[name=\"password\"]').nextSibling.textContent");
            if (checkPasswordError.Success == false || string.IsNullOrWhiteSpace(checkPasswordError.Result as string) == false)
            {
                result = false;
                HandleConsole.AddStatus(false, $"Result: {checkPasswordError.Result}");
            }
            else
            {
                HandleConsole.AddStatus(true, "Password has no error");
            }

            //Check if credentials has any error
            var checkCredentialsError = await browser.EvaluateScriptAsync($"document.querySelector('input[name=\"password\"]').nextSibling.nextSibling.textContent");
            if (checkCredentialsError.Success == false || string.IsNullOrWhiteSpace(checkCredentialsError.Result as string) == false)
            {
                result = false;
                HandleConsole.AddStatus(false, $"Result: {checkCredentialsError.Result}");
            }
            else
            {
                HandleConsole.AddStatus(true, "Credentials has no error");
            }
            return result;
        }
    }
}