using AdventureLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using WE03_ClassLibrary_AG.Classes;
using WE03_ClassLibrary_AG.Classes.Items;


namespace WE03_ClassLibrary_AG
{
    static class Program
    {
        private static Game game;

        private const ConsoleColor highlightColor = ConsoleColor.White;
        private const ConsoleColor badColor = ConsoleColor.Red;
        private const ConsoleColor goodColor = ConsoleColor.Green;
        private const ConsoleColor neutralColor = ConsoleColor.Blue;

        static void Main()
        {
            TextInfo testinfo = new CultureInfo("nl-BE", true).TextInfo;
            game = InitGame(ReadStringFromConsole("Before you embark on your grand adventure; what is your name? "));
            int headerHeight;
            int prevLeft, prevTop;

            Console.Clear();



            while (!game.GameOver)
            {
                prevLeft = Console.CursorLeft;
                prevTop = Console.CursorTop;

                // kamerinfo weergeven bovenaan scherm
                string lijntje = new string('=', game.World.CurrentRoom.Description.Length);
                headerHeight = 5 + game.World.CurrentRoom.ToString().Length / Console.WindowWidth;
                ClearLine(0, headerHeight);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(lijntje);
                Console.WriteLine(game.World.CurrentRoom);
                Console.WriteLine(lijntje);

                // als er items liggen in kamer deze weergeven
                if (game.World.CurrentRoom.Items?.Count > 0)
                {

                }


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
                        // gebruiker wil spel verlaten
                        game.GameOver = true;
                        break;
                    default:
                        break;
                }
                Console.ResetColor();
            }

            Console.ForegroundColor = (game.GameWon) ? goodColor : badColor;
            Console.WriteLine(game.GameOverMessage);
            Console.ResetColor();

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

        /// <summary>
        /// asks for input as long as user's input is null, empty, or consists of white-space characters.
        /// </summary>
        /// <param name="message">The message to display in the console</param>
        /// <returns>string containing the user's input</returns>
        private static string ReadStringFromConsole(string message)
        {
            string input;
            bool inputIsInvalid;

            Console.Write(message);
            Console.ForegroundColor = highlightColor;
            input = Console.ReadLine();
            inputIsInvalid = string.IsNullOrEmpty(input);
            if (inputIsInvalid)
            {
                Console.ForegroundColor = badColor;
                Console.WriteLine("That is not a valid input.\n");
            }
            Console.ResetColor();
            while (inputIsInvalid) ;

            return input;
        }

        private static void ClearLine(int top, int amount)
        {
            int origLeft = Console.CursorLeft;
            int origTop = Console.CursorTop;

            Console.SetCursorPosition(0, top);

            for (int i = 0; i < amount; i++)
            {
                Console.Write(new string(' ', Console.BufferWidth));
            }

            Console.SetCursorPosition(origLeft, origTop);
        }
    }
}
