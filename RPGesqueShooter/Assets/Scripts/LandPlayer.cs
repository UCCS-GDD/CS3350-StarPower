using UnityEngine;
using System.Collections;

public class LandPlayer : MonoBehaviour 
{
    // Variables for the axes
    float inputAxisX;
    float inputAxisY;

    public Rigidbody2D projectile;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        // if mouse button is down, fire gun
        if(Input.GetButtonDown("Primary Fire"))
        {
            Rigidbody2D clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
            clone.transform.position = new Vector2(clone.position.x, clone.position.y + 1);
            clone.velocity = transform.TransformDirection(Vector3.up * 10);
        }
	}

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        // Gets the axis input 
        inputAxisX = Input.GetAxis("Move Horizontal");
        inputAxisY = Input.GetAxis("Move Vertical");

        // linearly interpolates between the two vectors
        // the position of the object depending the the input
        if (inputAxisX != 0 || inputAxisY != 0)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(inputAxisX, inputAxisY), 5);
        }

        // clamps the player within the window
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), Mathf.Clamp(transform.position.y, -4.5f, 0));
    }
}
