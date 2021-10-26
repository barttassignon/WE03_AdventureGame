using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class FlowerPot : IItem, ILookable
    {
        public List<string> Names => new List<string> { "flower pot", "pot", "ornate pot", "ornate flower pot" };

        public string LookMessage()
        {
            return "A terracotta pot that hasn't been cleaned for some time.";
        }
        public override string ToString()
        {
            return "Flower pot";
        }
    }
}
