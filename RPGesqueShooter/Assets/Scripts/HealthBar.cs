using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // variable for health bar fill amount
    public static float healthFill = 1f;

    // Called every fixed framerate frame
    void FixedUpdate()
    {
        // gets the image compenent
        Image image = GetComponent<Image>();

        // set the fill amount for the health
        image.fillAmount = healthFill / 100;

        // if the GameObject PlayerRef is null
        // load the GameOver scene
        if (GameObject.Find("PlayerRef") == null)
        {
            Application.LoadLevel("GameOver");
        }

        // if the spacebar is down
        // load the HomeScreen scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("HomeScreen");
        }

    }
}
