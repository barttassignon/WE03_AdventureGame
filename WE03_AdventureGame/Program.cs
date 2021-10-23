using AdventureLib;
using System;
using System.Collections.Generic;

namespace WE03_ClassLibrary_AG
{
    class Program
    {


        static void Main(string[] args)
        {
            string invoer = Console.ReadLine();

            List<string> woorden;
            Parser.ParseCommand(invoer, out woorden);
        }
    }
}
