using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider = null;

    [SerializeField]
    private Health health = null;
    
    public void Start()
    {
        slider.maxValue = health.GetHealth();
        slider.value = health.GetHealth();
        
        health.OnTakeDamage += SetHealth;
    }
    
    public void SetHealth()
    {
        slider.value = health.GetHealth();
    }
}
