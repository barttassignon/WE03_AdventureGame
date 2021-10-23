using System;

namespace WE03_ClassLibrary_AG.Classes

{
    public class Game
    {
        public Player Player { get; set; }
        public World World { get; set; }
        public bool GameOver { get; set; }
        public bool GameWon { get; set; }

        public string GameOverMessage
        {
            get
            {
                return GameWon
                    ? "Congratulations, you've beaten the game"
                    : "There's no defeat, in thruth, save from within;\nUnless you're beaten there, you're bound to win!";
            }

        }

        public Game(Player player, World world)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player), "Without a player, there is no game...");
            World = world ?? throw new ArgumentNullException(nameof(world), "It would be rather empty around here without a World...");
        }

    }
}
