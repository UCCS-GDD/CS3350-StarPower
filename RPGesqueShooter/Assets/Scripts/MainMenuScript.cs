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
            Application.LoadLevel("HomeScreen");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void GetHelp()
        {

        }
    }
}
