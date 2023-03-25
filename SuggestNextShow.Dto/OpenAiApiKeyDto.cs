namespace SuggestNextShow.Dto
{
    /// <summary>
    /// Gets data from config and keep them to use in OpenAI package to communicate with Open Ai's api
    /// <br></br>
    /// <b>Note:</b>This key can obtain from <see href="https://platform.openai.com/account/api-keys">https://platform.openai.com/account/api-keys</see>
    /// <br></br>
    /// With record declaration this data shouldn't allowed to change.
    /// </summary>
    /// <param name="ApiKey">site to connect uri</param>
    public record OpenAiApiKeyDto(string ApiKey)
    {
    }
}