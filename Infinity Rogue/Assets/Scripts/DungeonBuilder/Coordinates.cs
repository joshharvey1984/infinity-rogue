using System;
using Random = UnityEngine.Random;

namespace InfinityRogue.DungeonBuilder {
    public class Coordinates {
        public int x { get; set; }
        public int y { get; set; }
        
        public static Direction OppositeDirection(Direction direction) {
            return direction switch {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public static Direction GetRandomDirection() => (Direction) Random.Range(1, 5);

        public static Coordinates DirectionCoordinates(Direction direction) {
            return direction switch {
                Direction.North => new Coordinates {x = 0, y = 1},
                Direction.South => new Coordinates {x = 0, y = -1},
                Direction.East => new Coordinates {x = 1, y = 0},
                Direction.West => new Coordinates {x = -1, y = 0},
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public static Coordinates GetNewCoordinates(Coordinates fromCoordinates, Direction direction) {
            var newCoordinates = DirectionCoordinates(direction);
            return new Coordinates{x = fromCoordinates.x + newCoordinates.x, y = fromCoordinates.y + newCoordinates.y};
        }
    }
}