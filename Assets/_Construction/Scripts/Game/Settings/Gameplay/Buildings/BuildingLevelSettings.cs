using UnityEngine;

namespace _Construction.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Game Settings/Buildings/New Building Level Settings")]
    public class BuildingLevelSettings : ScriptableObject
    {
        public int level;
        public double BaseIncome;
        public string PrefabName;
    }
}