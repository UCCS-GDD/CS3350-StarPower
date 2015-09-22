using UnityEngine;
using System.Collections;

public class BackdropScroll : MonoBehaviour 
{

    public float horScrollSpeed = 0;
    public float vertScrollSpeed = 1;

    Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();
    }

	void FixedUpdate () 
    {
        rend.material.SetTextureOffset("_MainTex", new Vector2(Time.time * horScrollSpeed, Time.time * vertScrollSpeed));
	}
}
