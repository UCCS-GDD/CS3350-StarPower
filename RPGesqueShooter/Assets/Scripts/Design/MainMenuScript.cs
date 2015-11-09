using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class MainMenuScript : MonoBehaviour
    {
        // Starts the game
        public void StartGame()
        {
            // Play menu sounds, load HomeScreen
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Score.playerScore = 0;
            Application.LoadLevel("CustomizationScreen");
        }

        // Quits the game
        public void QuitGame()
        {
            // Play menu sounds, quit game
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Application.Quit();
        }

        // Get help 
        public void GetHelp()
        {
            // Play help sounds
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        }
    }
}
