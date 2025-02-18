using System;
using System.Collections.Generic;
using _Construction.Game.State.GameResources;
using _Construction.Game.State.Maps;

namespace _Construction.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;
        public List<ResourceData> Resources;
        
        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}
