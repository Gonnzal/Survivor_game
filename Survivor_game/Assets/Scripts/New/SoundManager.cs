// SoundManager.cs
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicSource;
    public AudioSource hambientSource;
    public AudioSource sfxSource;
    public AudioClip[] sfxSounds;

    private AudioClip _pendingLoop;
    private bool _waitingForLoop = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // Detecta cuando la musica de Round 5 termina para arrancar el loop
        if (_waitingForLoop && !musicSource.isPlaying)
        {
            _waitingForLoop = false;
            musicSource.clip = _pendingLoop;
            musicSource.loop = true;
            musicSource.Play();
            _pendingLoop = null;
        }
    }

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        _waitingForLoop = false;
        _pendingLoop = null;
        musicSource.loop = loop;
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlayMusicThenLoop(AudioClip intro, AudioClip loopClip)
    {
        _pendingLoop = loopClip;
        _waitingForLoop = true;
        musicSource.loop = false;
        musicSource.clip = intro;
        musicSource.Play();
    }

    public void PlayHambient(AudioClip hambient, bool loop = true)
    {
        hambientSource.loop = loop;
        hambientSource.clip = hambient;
        hambientSource.Play();
    }

    public void StopMusic()
    {
        _waitingForLoop = false;
        _pendingLoop = null;
        musicSource.Stop();
    }

    public void StopHambient()
    {
        hambientSource.Stop();
    }

    public void PlaySFX(AudioClip clip, float volumen = 1f)
    {
        sfxSource.PlayOneShot(clip, volumen);
    }
}