using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour
{
    // Variable for projectile GameObject
    public GameObject projectile;

    // Variable for shootSound AudioClip
    public AudioClip shootSound;

    // Variable for AudioSource
    AudioSource source;

    // Used to inititalize any variables or game state before the game starts
    void Awake()
    {
        // get the AudioSource component
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // play sound once
        source.PlayOneShot(shootSound, .8f);

    }
}
