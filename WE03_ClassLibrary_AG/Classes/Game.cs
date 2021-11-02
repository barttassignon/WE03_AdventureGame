using System;
using WE03_ClassLibrary_AG.ENUMS;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes

{
    public class Game
    {
        public Player Player { get; set; }
        public World World { get; set; }
        public bool GameOver { get; set; }
        public bool GameWon { get; set; }

        public string GameOverMessage
        {
            get
            {
                return GameWon
                    ? "Congratulations, you've beaten the game"
                    : "There's no defeat, in thruth, save from within;\nUnless you're beaten there, you're bound to win!";
            }

        }

        public Game(Player player, World world)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player), "Without a player, there is no game...");
            World = world ?? throw new ArgumentNullException(nameof(world), "It would be rather empty around here without a World...");
        }


        public string Take(string itemName)
        {
            IItem item = FindItemInRoom(itemName, World.CurrentRoom);

            if (item != null)
            {
                if (item is ITakeable)
                {
                    World.CurrentRoom.Items.Remove(item);
                    Player.Inventory.Add(item);
                    return (item as ITakeable).TakeMessage();
                }
                else
                {
                    return "I don't want that.";
                }
            }
            else
            {
                return $"There's no {itemName}here.";
            }
        }

        public static Direction ToDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                case "north":
                    return Direction.NORTH;
                case "east":
                case "right":
                    return Direction.EAST;
                case "west":
                case "left":
                    return Direction.WEST;
                case "down":
                case "south":
                    return Direction.SOUTH;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }

        }

        private IItem FindItemInInventory(string itemName)
        {
            foreach (IItem item in Player.Inventory)
            {
                if (item.Names.Contains(itemName))
                {
                    return item;
                }
            }
            return null;
        }

        private static IItem FindItemInRoom(string itemName, Room room)
        {
            foreach (IItem roomitem in room.Items)
            {
                if (roomitem.Names.Contains(itemName))
                {
                    return roomitem;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
