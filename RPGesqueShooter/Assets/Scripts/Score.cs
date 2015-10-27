using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Variable for players score
    public static int playerScore = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get text component
        Text gt = this.GetComponent<Text>();

        // set text to the score
        gt.text = "Score: " + playerScore.ToString();
    }
}
