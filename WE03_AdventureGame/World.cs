namespace WE03_AdventureGame
{
    class World
    {
        public Room CurrentRoom { get; set; }

        public World(Room currentRoom)
        {
            CurrentRoom = currentRoom;
        }
    }
}
