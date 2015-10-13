using UnityEngine;
using System.Collections;

public class BackdropScroll : MonoBehaviour 
{
    // Public variables which hold the scrolling speed 
    // Horizontal and Vertical
    public float horScrollSpeed = 0;
    public float vertScrollSpeed = 1;

    // Renderer for the game
    Renderer rend;

    // Use this for initialization
    // Makes the objects appear on the screen
    public void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Called every fixed framerate frame if Monobehaviour is enabled
	void FixedUpdate () 
    {
        rend.material.SetTextureOffset("_MainTex", new Vector2(Time.time * horScrollSpeed, Time.time * vertScrollSpeed));
	}
}
