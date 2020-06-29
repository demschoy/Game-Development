using TMPro;
using UnityEngine;
using static InputStorage;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPlayerInputField = null;

    [SerializeField]
    private GameObject secondPlayerInputField = null;

    private string defaultFirstPlayerName = "Player 1";
    private string defaultSecondPlayerName = "Player 2";

    public void StoreNames()
    {
        FirstPlayerName = firstPlayerInputField.GetComponent<TextMeshProUGUI>().text;
        SecondPlayerName = secondPlayerInputField.GetComponent<TextMeshProUGUI>().text;
    }

    public void EraseFields()
    {
        firstPlayerInputField.GetComponent<TextMeshProUGUI>().text = defaultFirstPlayerName;
        secondPlayerInputField.GetComponent<TextMeshProUGUI>().text = defaultSecondPlayerName;
    }
}
