using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour {

	public GameObject projectile;
    public AudioClip shootSound;

    AudioSource source;



    void Awake () {
    
        source = GetComponent<AudioSource>();

    }


    void Update () {

        source.PlayOneShot(shootSound, .8f);
    
    }
}
