using UnityEngine;
using System.Collections;

public class SparkScript : MonoBehaviour {

    public ParticleSystem part;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        part = GetComponent<ParticleSystem>();
        audio = GetComponent<AudioSource>();
        part.Stop();
        part.Clear();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        part.Play();
        Debug.Log("You activated OnMouseDown");
        audio.Play();
    }

    void OnMouseUp()
    {
        part.Stop();
        audio.Stop();
        //part.Clear();
    }

}
