using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class Beer : IItem, IUsable, ILookable, ICombinableWith<Beer>
    {
        public List<string> Names => new List<string> { "beer", "bottle", "bottle of beer", "beer bottle" };

        public bool PlayerDrinkTooMuch { get; set; }
        public int DrinkCount;

        public string LookMessage()
        {
            return "I am not addicted to beer, but I just need it.";
        }
        /// <summary>
        /// Als de gebruiker use beer typt, zal dit door game.use() geinterpreteerd worden als "use beer on beer" of wij zien "drink beer"
        /// Er zullen berichtjes weergegeven worden naargelang de hoeveelheid 'use beers' er worden ingetypt.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string UsedWith(Beer item)
        {
            DrinkCount++;
            if (DrinkCount >= 2 && DrinkCount < 6)
            {
                return "You start feeling a little woozy.";
            }
            else if (DrinkCount >= 6 && DrinkCount <= 8)
            {
                return "The BeEr iS ReAllY starTinG tO gEt tO YouR HeAd.";
            }
            else if (DrinkCount > 8)
            {
                PlayerDrinkTooMuch = true;
                return "You really can't handle the alcohol very much, You stumble and pass out on the side of the road";
            }
            return "A little sip won't do any harm";

        }
        public override string ToString()
        {
            return "Bottle of beer";
        }
    }
}
