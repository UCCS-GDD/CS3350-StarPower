using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float scrollSpeed = 1;

    private Transform trans;
    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        trans.Translate(new Vector3(0, scrollSpeed * Time.deltaTime * -1, 0));
	}
}
