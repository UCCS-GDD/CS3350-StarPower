using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{

    public static float shieldFill = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Image image = GetComponent<Image>();

        image.fillAmount = shieldFill / 100;
    }
}
