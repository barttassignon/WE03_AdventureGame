namespace WE03_AdventureGame
{
    interface ITakeable
    {
        public string TakeMessage(string s)
        {
            return "Het item " + s + " is opgenomen.";
        }
    }
}
