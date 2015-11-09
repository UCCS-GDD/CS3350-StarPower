using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    // Variable for if the game is paused or not
    bool isPaused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Is user presses the P key is pauses the game
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = TogglePause();
        }
    }

    //
    void OnGUI()
    {
        // if game is paused
        if(isPaused)
        {
            // tell user game is paused 
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Game is Paused"); 

            // tell user game is paused
            //GUILayout.Label("Game is Paused");

            // create button to upause game
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 100), "Click to unpause game"))
            {
                isPaused = TogglePause();
            }
        }
    }

    // Toggles whether or not the game is paused
    bool TogglePause()
    {
        // if game is paused
        // return false
        if (Time.timeScale == 0f)
        {
            // unpause game
            Time.timeScale = 1f;
            return (false);
        }
         // if game is not paused
        // return true
        else
        {
            // pause game 
            Time.timeScale = 0f;
            return (true);
        }
    }
}