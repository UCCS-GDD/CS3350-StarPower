using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour
{
    // Goes to the MainMenu
    public void MainMenu()
    {
        // load the main menu scene
        SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        Application.LoadLevel("MainMenu");
    }
}
