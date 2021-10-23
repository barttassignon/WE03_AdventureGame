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
    }
}
