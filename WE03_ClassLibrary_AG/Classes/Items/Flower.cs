using System;
using System.Collections.Generic;
using WE03_ClassLibrary_AG.Interfaces;

namespace WE03_ClassLibrary_AG.Classes.Items
{
    public class Flower : IItem, ILookable, ICombinableWith<Beer>
    {
        public List<string> Names => throw new NotImplementedException();
        public bool IsBeered;

        public string LookMessage()
        {
            if (IsBeered)
            {
                return "It looks a bit wilted now. And it smels of stale beer.";
            }
            else
            {
                return "A beatiful, pearly white Jasmine is sitting in an ornate pot";
            }
        }

        public string UsedWith(Beer item)
        {
            if (IsBeered)
            {
                return "I think it's had enough";
            }
            else
            {
                IsBeered = true;
                return "U empty half of the beer into that flower. Watering a plant with beer seems unnecessary, not to mention smelly.";
            };
        }
        public override string ToString()
        {
            return "A flower";
        }
    }
}
