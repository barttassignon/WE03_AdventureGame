namespace WE03_AdventureGame
{
    class Game
    {
        public Player Player { get; set; }
        public World World { get; set; }
        public bool GameOver { get; set; }
        public bool GameWon { get; set; }

        public string GameOverMessage()
        {
            return "You have won the Game!";
        }

        public Game(Player player, World world)
        {
            Player = player;
            World = world;
        }

    }
}
