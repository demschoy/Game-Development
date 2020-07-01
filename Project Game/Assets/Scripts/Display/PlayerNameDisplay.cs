using TMPro;
using UnityEngine;
using static InputStorage;

public class PlayerNameDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPlayerDisplay = null;

    [SerializeField]
    private GameObject secondPlayerDisplay = null;

    public void Start()
    {   
        firstPlayerDisplay.GetComponent<TextMeshProUGUI>().text = FirstPlayerName;
        secondPlayerDisplay.GetComponent<TextMeshProUGUI>().text = SecondPlayerName;
    }
}
