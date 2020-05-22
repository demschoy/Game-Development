using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Camera))]

public class ScreenShaker : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve shakeCurve = null;

    [SerializeField]
    [Range(0, 5)]
    private float lightIntensity = 1;

    [SerializeField]
    [Range(0, 5)]
    private float heavyIntensity = 3;

    [SerializeField]
    [Range(0, 1)]
    private float shakeDuration = 0.05f;

    [SerializeField]
    private int cameraNoise = 10;

    private UnityEngine.Vector3 cameraPosition; 

    private static ScreenShaker instance;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = transform.position;
        instance = this;
    }

    private static void ShakeScreen(float intensity)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ShakeScreenCoroutine(intensity));
    }

    private IEnumerator ShakeScreenCoroutine(float intensity)
    {
        float startTime = Time.time;
        float endTime = startTime + shakeDuration;

        float noiseSeed = Random.value * 100;
        float noise = intensity * cameraNoise;
            
        while(Time.time < endTime)
        {
            float normalizedTime = (Time.time - startTime) / shakeDuration;
            float offsetX = PerlinNoise(noiseSeed + noise * Time.time, 0) * 2 - 1;
            float offsetY = PerlinNoise(0, noiseSeed + noise * Time.time) * 2 - 1;

            UnityEngine.Vector3 offset = new UnityEngine.Vector2(offsetX, offsetY) * shakeCurve.Evaluate(normalizedTime) * intensity;
            transform.position = cameraPosition + offset;
            yield return null;
        }
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += ShakeScreen;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= ShakeScreen;
    }
    public void ShakeScreen(UnityEngine.Vector3 transform, UnityEngine.Vector3 intensity)
    {
        if (intensity == UnityEngine.Vector3.zero)
        {
            ShakeScreen(instance.lightIntensity);
        }
        else if (intensity == UnityEngine.Vector3.one)
        {
            ShakeScreen(instance.heavyIntensity);
        }
    }
}
