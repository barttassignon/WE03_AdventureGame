using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class Door : IItem, ILookable, ICombinableWith<Key>, ICombinableWith<Can>
    {
        public List<string> Names => new List<string> { "door", "oak door", "massive door", "massive oak door" };

        public bool IsOpened { get; set; }

        public bool IsLubricated;

        public string LookMessage()
        {
            return "A massive oak door in the middle of the forest clearing. It's got a large keyhole covered with cobwebs.";
        }

        public string UsedWith(Key item)
        {
            if (IsLubricated)
            {
                IsOpened = true;
                return "The key fits! U slowly turn the key and slowly, but steadely, it opens!";
            }
            else
            {
                return "The key fits, but the hinges are rusted up. I couldn't possible open it.";
            };
        }

        public string UsedWith(Can can)
        {
            if (can.IsEmpty)
            {
                return "You press the sprayhead, but the can is empty.";
            }
            else
            {
                IsLubricated = true;
                can.IsEmpty = true;
                return "You spray a generous amount of WD40 on the door hinges until the can is empty. This seems to remove some of the rust.";
            };
        }

        public string UsedWith(IUsable item)
        {
            return "That doesn't have an effect on the door.";
        }

        public override string ToString()
        {
            return "An oak door";
        }
    }
}
