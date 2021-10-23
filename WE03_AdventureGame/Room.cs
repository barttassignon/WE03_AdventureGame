using System.Collections.Generic;

namespace WE03_AdventureGame
{
    class Room
    {
        public string Name { get; set; }
        public List<IItem> Items { get; set; }
        public Dictionary<string, string> Exits { get; set; }

        public Room(string name, List<IItem> list, Dictionary<string, string> exits)
        {
            Name = name;
            Items = new List<IItem>();
            Exits = new Dictionary<string, string>();
        }
    }
}
