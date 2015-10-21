using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class MainMenuScript : MonoBehaviour
    {
        public void StartGame()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Application.LoadLevel("HomeScreen");
        }

        public void QuitGame()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Application.Quit();
        }

        public void GetHelp()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        }
    }
}
