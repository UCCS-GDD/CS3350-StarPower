using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public static float healthFill = 1f;
	
	// Update is called once per frame
	void FixedUpdate () {
        Image image = GetComponent<Image>();

        image.fillAmount = healthFill / 100;
        

        if (GameObject.Find("PlayerRef") == null)
        {
            Application.LoadLevel("GameOver");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("HomeScreen");
        }

	}
}
