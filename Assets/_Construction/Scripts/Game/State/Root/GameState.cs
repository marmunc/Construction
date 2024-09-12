using System;
using System.Collections.Generic;

namespace _Construction.Scripts.Game
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public List<BuildingEntity> Buildings;
    }
}
