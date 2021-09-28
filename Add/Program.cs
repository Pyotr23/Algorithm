using System.Collections.Generic;
using System.Linq;

namespace Route256.OneStar.Add
{
    class Program
    {
        static void Main(string[] args)
        {
            // var setsCount = int.Parse(args[0]);
            // if ()
            Fill();
        }

        // private static bool IsPossibleToGet(int number)
        // {
        //     for (var i = 0; i < 10; i++)
        //     {
        //         
        //     }
        //     var res = number / 111;
        //     if (res >= 10)
        //         return true;
        //     
        //     if (res )
        // } 

        private static void Fill()
        {
            var set = new HashSet<int>(1000);
            for (var i = 0; i < 10; i++)
            {
                var j = 0;
                var res = 0;
                while (res < 1000)
                {
                    res = i * 111 + j * 11;
                    if (!set.Contains(res))
                        set.Add(res);
                    j++;
                }
            }

            var arr = set.OrderBy(x => x).ToArray();
        }
    }
}