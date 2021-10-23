using System.Collections.Generic;

namespace WE03_AdventureGame
{
    class Player
    {
        public string Name { get; set; }
        public List<IItem> Inventory { get; }

        public Player(string name, List<IItem> list)
        {
            Name = name;
            List<IItem> Inventory = list;
        }

        public Player(string name)
        {
            Name = name;
            List<IItem> Inventory = new List<IItem>();
        }
    }
}
