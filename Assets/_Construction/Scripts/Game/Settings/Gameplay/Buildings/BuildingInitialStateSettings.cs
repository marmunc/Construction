using System;
using UnityEngine;

namespace _Construction.Game.Settings.Gameplay.Buildings
{
    [Serializable]
    public class BuildingInitialStateSettings
    {
        public string TypeId;
        public int Level;
        public Vector3Int Position;
    }
}