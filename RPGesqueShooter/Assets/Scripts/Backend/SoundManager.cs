using UnityEngine;
using System.Collections;

// Enumeration for the different sound effects
public enum SoundEffect
{
    laser,
    menuSelect,
    shieldDown,
    shieldUp,
    explosion
}

public class SoundManager : MonoBehaviour
{
    // Variable for SoundManager
    public static SoundManager instance = null;

    // Varibles for AudioClips used in game
    public AudioClip laser;
    public AudioClip menuSelect;
    public AudioClip shieldDown;
    public AudioClip shieldUp;
    public AudioClip explosion;

    // Variable for AudioSource
    private AudioSource source;

    // Variable for AudioClip
    private AudioClip clip;

    // Used to inititalize any variables or game state before the game starts
    public void Awake()
    {
        // if SoundManager is null
        // set instance
        if (instance == null)
        {
            instance = this;
        }
        // if instance does not equal the source
        else if (instance != this)
        {
            // Destroy the object
            Destroy(gameObject);
        }
        // Does not allow for gameObject to be destroyed
        DontDestroyOnLoad(gameObject);

        // get the AudioSource components
        source = GetComponent<AudioSource>();
    }

    // Plays sound effect
    public void PlaySound(SoundEffect effect, float vol)
    {
        // set pitch of the sound
        source.pitch = 1f;

        // if the sound is an explosion
        if (effect == SoundEffect.explosion)
        {
            // play sound once
            source.PlayOneShot(explosion, vol);
        }
        // if sound is laser and NOT on the HomeScreen
        else if (effect == SoundEffect.laser && Application.loadedLevelName != "HomeScreen")
        {
            // play sound once
            source.PlayOneShot(laser, vol);
        }
        // if sound is menuSelect
        else if (effect == SoundEffect.menuSelect)
        {
            // play sound once
            source.PlayOneShot(menuSelect, vol);
        }
        // if the sound is shieldDown
        else if (effect == SoundEffect.shieldDown)
        {
            // play sound once
            source.PlayOneShot(shieldDown, vol);
        }
        // if the sound is the shieldUp
        else if (effect == SoundEffect.shieldUp)
        {
            // play sound once
            source.PlayOneShot(shieldUp, vol);
        }
    }
}
