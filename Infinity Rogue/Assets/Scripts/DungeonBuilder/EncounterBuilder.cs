using System;
using System.Collections.Generic;
using System.Linq;
using InfinityRogue.Data.Monsters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InfinityRogue.DungeonBuilder
{
    public class EncounterBuilder : MonoBehaviour {
        public static List<Type> Build(int powerLevel) {
            var monsters = new Dictionary<Type, int> {{typeof(Slime), 10}};

            var encounterMonsters = new List<Type>();

            var currentPowerLevel = 0;
            while (currentPowerLevel < powerLevel) {
                var a = Random.Range(0, monsters.Count);
                var ranMon = monsters.ElementAt(a).Key;
                var pl = monsters.ElementAt(a).Value;
                currentPowerLevel += pl;
                encounterMonsters.Add(ranMon);
            }

            return encounterMonsters;
        }
    }
}
