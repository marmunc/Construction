using System;
using _Construction.Scripts.Game;
using UnityEngine;

namespace _Construction.Game.State.Entities.Buildings
{
    [Serializable]
    public class BuildingEntity : Entity
    {
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}
