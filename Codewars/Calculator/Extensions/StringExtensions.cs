using Codewars.Three.Calculator.Helpers;

namespace Codewars.Three.Calculator.Extensions
{
    internal static class StringExtensions
    {
        internal static double ToDouble(this string value)
        {
            return double.Parse(value, CultureHelper.Culture);
        }
    }
}