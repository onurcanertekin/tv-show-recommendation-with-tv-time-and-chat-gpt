using OpenAI_API.Chat;
using SuggestNextShow.Entry.Handlers.Helpers;

namespace SuggestNextShow.Entry.Handlers
{
    /// <summary>
    /// Handle Open Ai Created Chat
    /// </summary>
    public static class HandleAiChat
    {
        /// <summary>
        /// Append instruction
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        public static void AppendSystemMessage(Conversation chat)
        {
            chat.AppendSystemMessage(
                @"I want you to act as a Tv Show Recommender, check this list and suggest next show.
                Note: your suggested show should not be in the list.");
        }

        /// <summary>
        /// Send show list to chat
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="showList"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void AppendUserInput(Conversation chat, List<string> showList)
        {
            chat.AppendUserInput(string.Join(",", showList));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task GetResponseFromChatbot(Conversation chat)
        {
            string response = await chat.GetResponseFromChatbot();
            HandleConsole.Exit(true, response);
        }
    }
}