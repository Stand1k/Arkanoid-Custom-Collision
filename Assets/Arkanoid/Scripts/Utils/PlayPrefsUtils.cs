using UnityEngine;

namespace Arkanoid
{
    public class PlayPrefsUtils : Singleton<PlayPrefsUtils>
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SetNextLvl()
        {
            PlayerPrefs.SetInt("CurrentLvl", GetCurrentLvl() + 1);
        }

        public int GetCurrentLvl()
        {
            return PlayerPrefs.HasKey("CurrentLvl") ? PlayerPrefs.GetInt("CurrentLvl") : 0;
        }
    }
}