﻿using SuggestNextShow.Dto;
using System.Configuration;

namespace SuggestNextShow.Entry
{
    /// <summary>
    /// read configuration datas from App.config file and return them.
    /// </summary>
    internal static class ConfigManager
    {
        /// <summary>
        /// Gets Username and Password from config to auth in cars.com
        /// </summary>
        /// <returns>Initialized record object with filled credintial information</returns>
        internal static CredentialsDto GetCredentials()
        {
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            return new CredentialsDto(username, password);
        }

        /// <summary>
        /// Get site uri to connect
        /// </summary>
        /// <returns></returns>
        internal static SiteUriDto GetUri()
        {
            return new SiteUriDto(ConfigurationManager.AppSettings["siteUri"]);
        }

        /// <summary>
        /// Get OpenAi Key to communicate with Api
        /// <br></br>
        /// <b>Note:</b>This key can obtain from <see href="https://platform.openai.com/account/api-keys">https://platform.openai.com/account/api-keys</see>
        /// </summary>
        /// <returns></returns>
        internal static OpenAiApiKeyDto GetOpenAikey()
        {
            return new OpenAiApiKeyDto(ConfigurationManager.AppSettings["openAiApiKey"]);
        }
    }
}