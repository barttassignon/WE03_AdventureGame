using AdventureLib;
using System;
using System.Collections.Generic;

namespace WE03_AdventureGame
{
    class Program
    {
        enum Direction
        {
            NORTH, EAST, SOUTH, WEST
        }

        static void Main(string[] args)
        {
            string invoer = Console.ReadLine();

            List<string> woorden;
            Parser.ParseCommand(invoer, out woorden);
        }
    }
}
