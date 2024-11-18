using System;
using System.Collections.Generic;
using _Construction.Game.Settings.Gameplay.Buildings;

namespace _Construction.Game.Settings.Gameplay.Maps
{
    [Serializable]
    public class MapInitialStateSettings
    {
        public List<BuildingInitialStateSettings> Buildings;
    }
}