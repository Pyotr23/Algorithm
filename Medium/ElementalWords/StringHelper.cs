using System.Collections.Generic;

namespace Codewars.Four.ElementalWords
{
    internal static class StringHelper
    {
        internal static string GetJoinedString(IEnumerable<string> stringParts)
        {
            return string.Join("", stringParts);
        }
        
        internal static string GetJoinedViaCommaString(IEnumerable<string> stringParts)
        {
            return string.Join(", ", stringParts);
        }
    }
}