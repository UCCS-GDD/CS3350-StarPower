using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour
{
    // Goes to the MainMenu
    public void MainMenu()
    {
        // load the main menu scene
        SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        Score.playerScore = 0;
        Application.LoadLevel("MainMenu");
    }

    // Goes to the Customization Screen
    public void NewGame()
    {
        SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        Score.playerScore = 0;
        Application.LoadLevel("CustomizationScreen");
    }

    // Quits the game
    public void QuitGame()
    {
        SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);
        Application.Quit();
    }
}
