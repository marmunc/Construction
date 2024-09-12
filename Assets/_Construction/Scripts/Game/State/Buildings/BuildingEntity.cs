using System;
using UnityEngine;

namespace _Construction.Scripts.Game
{
    [Serializable]
    public class BuildingEntity
    {
        public int Id;
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}
