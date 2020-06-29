using TMPro;
using UnityEngine;
using static Controllers;

public class HowToPlayControlsDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI firstPlayerControls = null;

    [SerializeField]
    private TextMeshProUGUI secondPlayerControls = null;

    public void DisplayControls()
    {
        DisplayFirstControls();
        DisplaySecondControls();
    }

    private void DisplayFirstControls()
    {
        string controls = GetFirstPlayerShootKey() + "\n"
                        + GetFirstPlayerLeftKey() + "\n"
                        + GetFirstPlayerRightKey();
        firstPlayerControls.text = controls;
    }

    private void DisplaySecondControls()
    {
        string controls = GetSecondPlayerShootKey() + "\n"
                        + GetSecondPlayerLeftKey() + "\n"
                        + GetSecondPlayerRightKey();

        secondPlayerControls.text = controls;
    }
}
