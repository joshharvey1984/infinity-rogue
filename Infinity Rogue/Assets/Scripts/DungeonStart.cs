using System.Collections.Generic;
using InfinityRogue.DungeonBuilder;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InfinityRogue {
    public partial class DungeonStart : MonoBehaviour {
        public GameObject Room;
        
        public GameObject MapRoom;
        public GameObject MapDoor;

        public GameObject MapUI;
        public GameObject Grid;

        private Dungeon dungeon;
        
        private List<GameObject> mapRooms;
        private List<GameObject> rooms;

        [SerializeField] private int Levels;
        [SerializeField] private int MinRooms;
        [SerializeField] private int MaxRooms;
        [SerializeField] private int MaxX;
        [SerializeField] private int MaxY;



        private void Start() {
            //mapRooms = new List<GameObject>();
            rooms = new List<GameObject>();
            CreateDungeon();
            //CreateDungeonMap();
        }

        private void Update() {
            if (Input.GetKeyUp(KeyCode.A)) {
                DestroyDungeon();
                CreateDungeon();
                //CreateDungeonMap();
            }
        }

        private void CreateDungeon() {
            var dungeonParams = new DungeonParameters {
                Levels = Levels,
                MaxX = MaxX,
                MaxY = MaxY,
                MinRooms = MinRooms,
                MaxRooms = MaxRooms
            };
            dungeon = new Dungeon(dungeonParams);
            foreach (var room in dungeon.Levels[0].Rooms) { 
                var newRoom = Instantiate(Room, new Vector3(room.Coordinates.x * 1.1F, room.Coordinates.y * 1.1F),
                Quaternion.identity, gameObject.transform);
                newRoom.name = room.Coordinates.x + "-" + room.Coordinates.y;
                rooms.Add(newRoom);
                RoomLightOff(newRoom);
            }

            RoomLightOn(rooms[0]);
        }

        private void DestroyDungeon() {
            foreach (var room in rooms) {
                Destroy(room);
            }

            rooms.Clear();
        }

        private void CreateDungeonMap() {
            foreach (var room in dungeon.Levels[0].Rooms) {
                var newRoom = Instantiate(MapRoom, new Vector3(room.Coordinates.x, room.Coordinates.y * 0.75F),
                    Quaternion.identity, MapUI.transform);
                var roomPos = newRoom.transform.position;
                foreach (var connectingRoom in room.ConnectingRooms) {
                    if (connectingRoom.Key == Direction.North) {
                        Instantiate(MapDoor, new Vector3(roomPos.x, roomPos.y + 0.3F), Quaternion.identity,
                            newRoom.transform);
                    }

                    if (connectingRoom.Key == Direction.South) {
                        Instantiate(MapDoor, new Vector3(roomPos.x, roomPos.y - 0.3F), Quaternion.identity,
                            newRoom.transform);
                    }

                    if (connectingRoom.Key == Direction.East) {
                        Instantiate(MapDoor, new Vector3(roomPos.x + 0.45f, roomPos.y), Quaternion.identity,
                            newRoom.transform);
                    }

                    if (connectingRoom.Key == Direction.West) {
                        Instantiate(MapDoor, new Vector3(roomPos.x - 0.45f, roomPos.y), Quaternion.identity,
                            newRoom.transform);
                    }
                }

                mapRooms.Add(newRoom);
            }
        }

        private void RoomLightOff(GameObject room) {
            foreach (var tilemapRenderer in room.GetComponentsInChildren<TilemapRenderer>()) {
                tilemapRenderer.material.color = Color.black;
            }
        }
        
        private void RoomLightOn(GameObject room) {
            foreach (var tilemapRenderer in room.GetComponentsInChildren<TilemapRenderer>()) {
                tilemapRenderer.material.color = Color.white;
            }
        }
    }
}