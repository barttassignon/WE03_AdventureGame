using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public List<IItem> Inventory { get; }

        public Player(string name, List<IItem> startInventory)
        {
            Name = name;
            Inventory = startInventory;
        }

        public Player(string name) : this(name, new List<IItem>())
        {

        }
    }
}
