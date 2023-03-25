using StockBridge.Handler;

namespace SuggestNextShow.Entry.Handlers.Helpers
{
    /// <summary>
    /// Handler for List operations
    /// </summary>
    public static class HandleLists
    {
        /// <summary>
        /// Turn object list into string list
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static List<string?> ObjectListToStringList(List<object> objects)
        {
            List<string?> list = new();
            foreach (object obj in objects)
            {
                list.Add(Convert.ToString(obj).ClearUnwantedCharacters());
            }
            return list;
        }
    }
}