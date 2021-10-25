using AdventureLib;
using System;
using System.Collections.Generic;

namespace WE03_ClassLibrary_AG
{
    class Program
    {


        static void Main(string[] args)
        {

            bool doorgaan = true;
            while (doorgaan)
            {
                Console.WriteLine("What do you want to do?");
                string invoer = Console.ReadLine();
                List<string> woorden;
                Parser.ParseCommand(invoer, out woorden);
                switch (Parser.ParseCommand(invoer, out woorden))
                {
                    case Parser.CommandType.Undefined:
                        Console.WriteLine("I don't know what you mean?");
                        break;
                    case Parser.CommandType.Use:
                        Console.WriteLine("You want to use: " + string.Join(", ", woorden));
                        break;
                    case Parser.CommandType.Take:
                        break;
                    case Parser.CommandType.Look:
                        Console.WriteLine("You want to look at: " + string.Join(", ", woorden));
                        break;
                    case Parser.CommandType.Move:
                        break;
                    case Parser.CommandType.Exit:
                        doorgaan = false;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
