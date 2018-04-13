namespace GW2NET
{
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public static class HeaderExtensions
    {
        public static void AddRange(this HttpHeaders headers, IEnumerable<KeyValuePair<string, string>> addList)
        {
            foreach (var pair in addList)
            {
                headers.Add(pair.Key, pair.Value);
            }
        }

        public static void AddRange(this HttpHeaders headers, IEnumerable<KeyValuePair<string, IEnumerable<string>>> addList)
        {
            foreach (var pair in addList)
            {
                headers.Add(pair.Key, pair.Value);
            }
        }
    }
}