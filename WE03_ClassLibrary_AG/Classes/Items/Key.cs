using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class Key : IItem, ITakeable, IUsable, ILookable
    {
        public List<string> Names => new List<string> { "key", "unwieldy key", "large key", "old key", "old looking key" };

        public string TakeMessage()
        {
            return "You decide to take the key in your pocket, should you need it.";
        }

        public string LookMessage()
        {
            return "A rather unwieldy, old looking key. It must have been lying her for ages!";
        }
        public override string ToString()
        {
            return "Old key";
        }
    }
}
