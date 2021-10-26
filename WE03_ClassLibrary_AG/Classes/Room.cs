using System;
using System.Collections.Generic;
using WE03_ClassLibrary_AG.ENUMS;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IItem> Items { get; set; }
        public Dictionary<Direction, Room> Exits { get; set; }

        public Room(string name, List<IItem> list, Dictionary<string, string> exits)
        {
            Name = name;
            Items = new List<IItem>();
            Exits = new Dictionary<Direction, Room>();
        }

        public Room()
        {
            Exits = new Dictionary<Direction, Room>();
            Items = new List<IItem>();
        }

        public void AddRoom(Direction direction, Room room)
        {
            Exits.Add(direction, room);
            room.Exits.Add(GetInverseDirection(direction), this);

        }
        // als de cases van een switch niet veel code bevatten, kan je vanaf C# 8 de switch expression gebruiken en het resultaat meteen returnen
        // cf.: https://www.c-sharpcorner.com/article/c-sharp-8-0-new-feature-swtich-expression/
        // en https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
        private static Direction GetInverseDirection(Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => Direction.SOUTH,
                Direction.SOUTH => Direction.NORTH,
                Direction.WEST => Direction.EAST,
                Direction.EAST => Direction.WEST,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Enum value not recognized"),
            };
        }
        /// <summary>
        /// Returns the name and the description of the room in the following format:
        ///
        /// ROOM NAME
        /// Description of the room.
        /// </summary>
        /// <returns>The name and the description of the room.</returns>
        public override string ToString()
        {
            return $"{Name.ToUpperInvariant()}\n{Description}";
        }
    }
}
