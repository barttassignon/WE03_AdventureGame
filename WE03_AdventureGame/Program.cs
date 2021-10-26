using AdventureLib;
using System;
using System.Collections.Generic;
using WE03_ClassLibrary_AG.Classes;
using WE03_ClassLibrary_AG.Classes.Items;

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

        private static Game InitGame(string playerName)
        {
            Beer beer = new Beer();

            Player player = new Player(playerName, new List<Interfaces.IItem> { beer });

            Room towncentre = new Room { Name = "Towncentre", Description = "The centre of the town. To the left is the local bar and up ahead is the forest." };
            Room forest = new Room { Name = "Forest", Description = "A darke dense forest. A clearing in the middle reveals a strange wooden door" };
            forest.Items = new List<Interfaces.IItem> { new Door() };

            Room bar = new Room { Name = "Bar", Description = "The sleaziest, grubbiest bar you've ever seen" };
            bar.Items = new List<Interfaces.IItem> { new Flower(), new FlowerPot(), new Key() };

            Room seaside = new Room { Name = "Seaside", Description = "A beatiful beach and a sky-blue sea." };
            seaside.Items = new List<Interfaces.IItem> { new Can() };

            towncentre.AddRoom(ENUMS.Direction.NORTH, forest);
            towncentre.AddRoom(ENUMS.Direction.WEST, bar);
            towncentre.AddRoom(ENUMS.Direction.SOUTH, seaside);

            World world = new World(towncentre);
            return new Game(player, world);
        }
    }
}
