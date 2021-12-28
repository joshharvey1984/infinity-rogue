using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace InfinityRogue.DungeonBuilder {
    public class Level {
        private int _level;
        public List<Room> Rooms = new();

        public Level(int level) {
            _level = level;
        }

        [CanBeNull]
        public Room GetRoomByCoordinates(Coordinates coordinates) => Rooms.
            FirstOrDefault(room => coordinates.x == room.Coordinates.x && coordinates.y == room.Coordinates.y);
        
    }
}