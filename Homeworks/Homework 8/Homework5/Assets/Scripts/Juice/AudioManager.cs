using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] 
    private AudioSource hitAudio = null;
    [SerializeField] 
    private AudioSource hurtAudio = null;
    [SerializeField] 
    private AudioSource dieAudio = null;

    private static AudioManager instance;

    private void Start()
    {
        instance = this;
    }

    public static void PlayHitAudio()
    {
        instance.hitAudio.Play();
        print("hit");
    }

    public static void PlayHurtAudio()
    {
        instance.hurtAudio.Play();
        print("hurt");
    }

    public static void PlayDieAudio()
    {
        instance.dieAudio.Play();
    }
}
