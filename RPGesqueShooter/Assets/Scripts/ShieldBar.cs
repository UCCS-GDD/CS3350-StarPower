using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    // Variable for shield
    public static float shieldFill = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the image component
        Image image = GetComponent<Image>();

        // set the fillAmount
        image.fillAmount = shieldFill / 100;
    }
}
