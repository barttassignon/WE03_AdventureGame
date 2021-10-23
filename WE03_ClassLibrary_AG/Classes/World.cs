using System;

namespace WE03_ClassLibrary_AG.Classes
{
    public class World
    {
        public Room CurrentRoom { get; set; }

        public World(Room startingRoom)
        {
            CurrentRoom = startingRoom ?? throw new ArgumentNullException(nameof(startingRoom));
        }
    }
}
