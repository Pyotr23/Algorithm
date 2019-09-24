using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_1108_defanging_an_ip_address
    {
        static void Main(string[] args)
        {
            string ip = "255.100.50.0";
            Console.WriteLine(DefangIPaddr(ip));
            Console.ReadKey();
        }

        private static string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
}
