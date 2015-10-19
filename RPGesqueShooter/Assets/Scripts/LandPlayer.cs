using UnityEngine;
using System.Collections;

public class LandPlayer : MonoBehaviour 
{
    // Variables for the axes
    float inputAxisX;
    float inputAxisY;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        // Gets the axis input 
        inputAxisX = Input.GetAxis("Move Horizontal");
        inputAxisY = Input.GetAxis("Move Vertical");

        // 
        if (inputAxisX != 0 || inputAxisY != 0)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(inputAxisX, inputAxisY), 5);
        }

        // clamps the player within the window
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), Mathf.Clamp(transform.position.y, -4.5f, 0));
    }
}
