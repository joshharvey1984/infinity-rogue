namespace InfinityRogue.DungeonBuilder {
    public static class LevelBuilder {
        private static DungeonParameters _dungeonParameters;
        
        private static Room _currentRoom;
        private static Level _level;

        public static Level BuildLevel(Level level, DungeonParameters dungeonParameters) {
            _dungeonParameters = dungeonParameters;
            _level = level;
            
            var coordinates = new Coordinates {x = 0, y = 0};
            _currentRoom = NewRoom(coordinates);
            
            while (_level.Rooms.Count < dungeonParameters.MaxRooms) {
                Coordinates newRoomCoordinates;
                Direction newDirection;
                
                do {
                    newDirection = Coordinates.GetRandomDirection();
                    newRoomCoordinates = Coordinates.GetNewCoordinates(_currentRoom.Coordinates, newDirection);
                } while (!CheckInbounds(newRoomCoordinates));
                
                var checkRoom = _level.GetRoomByCoordinates(newRoomCoordinates) ?? NewRoom(newRoomCoordinates);

                checkRoom.ConnectingRooms[Coordinates.OppositeDirection(newDirection)] = _currentRoom;
                _currentRoom.ConnectingRooms[newDirection] = checkRoom;
                
                _currentRoom = checkRoom;
            }
            
            return _level;
        }

        private static Room NewRoom(Coordinates coordinates) {
            var newRoom = new Room(coordinates);
            _level.Rooms.Add(newRoom);
            return newRoom;
        }

        private static bool CheckInbounds(Coordinates coordinates) => (uint) coordinates.x <= _dungeonParameters.MaxX &&
                                                                      (uint) coordinates.y <= _dungeonParameters.MaxY;
    }
}