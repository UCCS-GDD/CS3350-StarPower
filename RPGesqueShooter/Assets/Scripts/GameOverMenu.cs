﻿using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour
{
    // Goes to the MainMenu
    public void MainMenu()
    {
        // load the main menu scene
        Application.LoadLevel("MainMenu");
    }
}