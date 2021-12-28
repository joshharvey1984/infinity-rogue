using System.Collections.Generic;

namespace InfinityRogue.DungeonBuilder {
    public class Dungeon {
        private readonly DungeonParameters _dungeonParameters;
        private Room _startRoom;

        public readonly List<Level> Levels = new();

        public Dungeon(DungeonParameters dungeonParameters) {
            _dungeonParameters = dungeonParameters;
            GenerateDungeon();
        }

        private void GenerateDungeon() {
            var startLevel = new Level(0);
            Levels.Add(LevelBuilder.BuildLevel(startLevel, _dungeonParameters));
        }
    }
}