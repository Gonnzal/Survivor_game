using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSorce;
    public AudioSource hambientSorce;
    public AudioSource sfxSorce;

    public AudioClip[] musics;
    public AudioClip hambient;
    public AudioClip[] sfxSounds;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(AudioClip music)
    { 
        musicSorce.clip = music;
        musicSorce.Play(); 
    }

    public void PlayHambient(AudioClip hambient)
    { 
        musicSorce.clip = hambient;
        musicSorce.Play(); 
    }

    public void PlaySFX(AudioClip clip, float volumen = 1f)
    {
        sfxSorce.PlayOneShot(clip, volumen);
    }
}
