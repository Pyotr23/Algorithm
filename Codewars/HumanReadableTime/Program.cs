using System;

namespace Codewars.Five.HumanReadableTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetReadableTime(0));
        }
        
        public static string GetReadableTime(int seconds)
        {
            var timespan = TimeSpan.FromSeconds(seconds);
            var result = timespan.ToString(@"hh\:mm\:ss");
            
            if (timespan.Days == 0)
                return result;
            
            var hours = timespan.Days * 24 + timespan.Hours;
            return result
                .Remove(0, 2)
                .Insert(0, hours.ToString());
        }
    }
}