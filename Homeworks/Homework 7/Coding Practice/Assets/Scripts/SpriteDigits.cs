using UnityEngine;
using UnityEngine.UI;

public class SpriteDigits : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images = new Sprite[0];
   
    [SerializeField]
    private Image hundreds = null;
    [SerializeField]
    private Image tens = null;
    [SerializeField]
    private Image ones = null;

    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        hundreds.sprite = images[1];
        tens.sprite = images[0];
        ones.sprite = images[0];

    }

    public void SetNumber(int value, int maxValue)
    {
        if(value == maxValue)
        {
            return;
        }

        int damageInterval = maxValue/ damage;
        for (int i = 0; i < damageInterval; i++)
        {
            if (value == i * damage)
            {
                hundreds.enabled = false;
                tens.sprite = images[i];
                ones.sprite = images[0];
            }
        }
    }
}
