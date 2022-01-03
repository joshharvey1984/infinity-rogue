using System;
using System.Collections.Generic;

namespace InfinityRogue.DungeonBuilder
{
    public class Encounter
    {
        private List<Type> _monsters;
        private int _powerLevel;

        public Encounter(int powerLevel)
        {
            _powerLevel = powerLevel;
            _monsters = EncounterBuilder.Build(powerLevel);
        }
    }
}