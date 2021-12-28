using System.Collections.Generic;

namespace InfinityRogue.DungeonBuilder {
    public class Room {
        public Dictionary<Direction, Room> ConnectingRooms;
        public readonly Coordinates Coordinates;

        public Room(Coordinates coordinates) {
            Coordinates = coordinates;
            ConnectingRooms = new Dictionary<Direction, Room>();
        }
    }
}