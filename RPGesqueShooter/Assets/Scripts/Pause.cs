using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    // Variable for if the game is paused or not
    bool isPaused = false;

    public Font font;
    public int fontSize; 

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

    // Sets up the GUI
    void OnGUI()
    {
        // Set font for GUI
        GUI.skin.label.font = GUI.skin.button.font = GUI.skin.box.font = font;

        // Sets font size for GUI
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;

        // if game is paused
        if(isPaused)
        {
            // instructions
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 4 - 80, (Screen.height) / 2 - 400, 800, 500), "How to Play Game:\nUse Left Arrow key to move Left\nUse Right Arrow key to move Right\nUse Up Arrow key to move Upwards\nUse Down Arrow key to move Downwards\nCollect PowerUps Dropped by Dead Enemies\nUse Left Mouse button to Fire your Primary Weapon\nUse Right Mouse button to Fire your Secondary Weapon\n");

            // tell user game is paused 
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Game is Paused!");

            // set background color of GUI to be green
            GUI.backgroundColor = Color.green;

            // create button to upause game
            if(GUI.Button(new Rect(Screen.width / 2 - (Screen.width) / 8, Screen.height / 2 - 60, 350, 100), "Click to Continue Game"))
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