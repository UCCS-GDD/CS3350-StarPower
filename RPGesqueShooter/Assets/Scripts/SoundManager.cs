using UnityEngine;
using System.Collections;

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

    public static SoundManager instance = null;

    public AudioClip laser;
    public AudioClip menuSelect;
    public AudioClip shieldDown;
    public AudioClip shieldUp;
    public AudioClip explosion;

    private AudioSource source;
    private AudioClip clip;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundEffect effect, float vol)
    {
        source.pitch = 1f;

        if (effect == SoundEffect.explosion)
        {
            source.PlayOneShot(explosion, vol);
        }
        else if (effect == SoundEffect.laser)
        {
            source.PlayOneShot(laser, vol);
        }
        else if (effect == SoundEffect.menuSelect)
        {
            source.PlayOneShot(menuSelect, vol);
        }
        else if (effect == SoundEffect.shieldDown)
        {
            source.PlayOneShot(shieldDown, vol);
        }
        else if (effect == SoundEffect.shieldUp)
        {
            source.PlayOneShot(shieldUp, vol);
        }
    }

}
