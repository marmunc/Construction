using _Construction.Game.Settings.Gameplay.Buildings;
using _Construction.Game.Settings.Gameplay.Maps;
using UnityEngine;

namespace _Construction.Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings/New Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public BuildingsSettings BuildingsSettings;
        public MapsSettings MapsSettings;
    }
}