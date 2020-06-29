using TMPro;
using UnityEngine;
using static SoundManager;

public class SoundButtonDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buttonText = null;

    private bool isSoundOn = true;
    private string turnMusicOn = "Sound On";
    private string turnMusicOff = "Sound Off";

    public void Start()
    {
        isSoundOn = SoundOn;
        ChangeSoundButtonText();    
    }

    public void SwitchMusicOnAndOff()
    {
        isSoundOn = !isSoundOn;
        ChangeSoundButtonText();
    }

    private void ChangeSoundButtonText()
    {
        if (isSoundOn)
        {
            buttonText.text = turnMusicOff;
        }
        else
        {
            buttonText.text = turnMusicOn;
        }
    }
}
