using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static bool SoundOn { get; set; } = true;

    public static Action<bool> OnSoundStateChanged;
    
    public void SetSoundState()
    {
        SoundOn = !SoundOn;
        OnSoundStateChanged?.Invoke(SoundOn);
    }

}
