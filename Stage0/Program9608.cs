using System;

namespace Stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome9608();
            Welcome0371();
            Console.ReadKey();
        }
        static partial void Welcome0371();
        private static void Welcome9608()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("{0}, welcome  to my first console application", userName);
        }
    }

}