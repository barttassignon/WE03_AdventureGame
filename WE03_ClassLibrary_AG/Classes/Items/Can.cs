using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class Can : IItem, ILookable, ITakeable, IUsable
    {
        /// <summary>
        /// Na gebruik op item Door is can Empty
        /// </summary>
        public bool IsEmpty { get; set; }

        public List<string> Names => new List<string> { "can", "rusty can", "can of WD40", "WD40", "lubricant", "can of lubricant" };

        public string LookMessage()
        {
            if (IsEmpty)
            {
                return "An empty can of WD40.";
            }
            else
            {
                return "A can of WD40. \"Lubricates almost anything\"";
            }
        }

        public string TakeMessage()
        {
            return "It's all greasy! Without getting your hands filthy, u quickly put it in your bag.";
        }
        public override string ToString()
        {
            return "A can of WD40";
        }
    }
}
