using System;
using UnityEngine;

namespace _Construction.Scripts.Game
{
    [Serializable]
    public class BuildingEntity : Entity
    {
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}
