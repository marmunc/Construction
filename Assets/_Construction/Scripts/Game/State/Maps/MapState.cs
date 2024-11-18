using System;
using System.Collections.Generic;
using _Construction.Game.State.Entities.Buildings;
using _Construction.Scripts.Game;

namespace _Construction.Game.State.Maps
{
    [Serializable]
    public class MapState
    {
        public int Id;
        public List<BuildingEntity> Buildings;
    }
}