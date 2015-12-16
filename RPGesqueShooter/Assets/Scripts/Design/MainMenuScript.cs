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
            // Play menu sounds, load CustomizationScreen
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Score.playerScore = 0;
            Application.LoadLevel("MissionSelect");
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
            Application.LoadLevel("HelpMenu");
        }

        public void ViewCredits()
        {
            // Play help sounds
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Application.LoadLevel("Credits");
        }

        public void MainMenu()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
            Application.LoadLevel("MainMenu");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Application.LoadLevel("BossLevel");
            }

			if (Input.GetKeyDown (KeyCode.L)) {
				Application.LoadLevel("lightningtest");
			}

        }
    }
}
