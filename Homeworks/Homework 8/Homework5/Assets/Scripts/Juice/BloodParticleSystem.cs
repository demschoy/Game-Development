using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ParticleSystem bloodParticles = null;

    private void OnEnable()
    {
        Health.OnTakeDamage += BloodSplash;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= BloodSplash;
    }

    public void BloodSplash(Vector3 position)
    {
        bloodParticles.gameObject.SetActive(true);
        bloodParticles.Play();
    }
}
