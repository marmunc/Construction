using UnityEngine;

namespace _Construction.Game.Settings
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = "Game Settings/New Application Settings")]
    public class ApplicationSettings : ScriptableObject
    {
        public int MusicVolume;
        public int SFXVolume;
        public string Difficulty;
    }
}