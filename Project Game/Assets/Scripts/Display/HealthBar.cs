using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hitsLeftText = null;
    [SerializeField]
    private Health health = null;
    [SerializeField]
    private Slider healthSlider = null;
    
    void Start()
    {
        healthSlider.maxValue = health.MaxHitsToTake;
        healthSlider.value = health.MaxHitsToTake;

        hitsLeftText.text = health.HitsLeft.ToString() + "/" + health.MaxHitsToTake.ToString();
    }

    private void OnEnable   ()
    {
        health.OnDamageTaken += UpdateHealthSlider;
    }

    private void OnDisable()
    {
        health.OnDamageTaken -= UpdateHealthSlider;
    }

    private void UpdateHealthSlider(int hitsLeft)
    {
        healthSlider.value = hitsLeft;
        hitsLeftText.text = hitsLeft.ToString() + "/" + health.MaxHitsToTake.ToString();
    }
}

