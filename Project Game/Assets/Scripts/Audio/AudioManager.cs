using UnityEngine;
using static SoundManager;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource music = null;
    [SerializeField]
    private AudioSource hitSound = null;
    [SerializeField]
    private AudioSource hurtSound = null;
    [SerializeField]
    private AudioSource deathSound = null;
    [SerializeField]
    private AudioSource buttonClickSound = null;

    private static AudioManager instance;

    private void Start()
    {
        instance = this;
        OnSoundStateChanged?.Invoke(SoundOn);
    }

    private void OnEnable()
    {
        OnSoundStateChanged += SwitchMusicOnAndOff;
    }

    private void OnDisable()
    {
        OnSoundStateChanged -= SwitchMusicOnAndOff;
    }

    public static void SwitchMusicOnAndOff(bool IsOn) 
    {
        if(IsOn)
        {
            instance.music.Play();
        }
        else
        {
            instance.music.Stop();
        }
    }

    public void ButtonClickSound()
    {
        if(SoundOn)
        {
            instance.buttonClickSound.Play();
        }
        else
        {
            instance.buttonClickSound.Stop();
        }
    }

    public static void PlayHitSound()
    {
        if(SoundOn)
        {
            instance.hitSound.Play();
        }
        else
        {
            instance.hitSound.Stop();
        }
    }

    public static void PlayHurtSound()
    {
        if(SoundOn)
        {
            instance.hurtSound.Play();
        }
        else
        {
            instance.hurtSound.Stop();
        }
    }

    public static void PlayDeathSound()
    {
        if(SoundOn)
        {
            instance.deathSound.Play();
        }
        else
        {
            instance.deathSound.Stop();
        }
    }
}