using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;
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

    private static ScreenShaker instance;

    // Start is called before the first frame update
    void Start()
    {
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
        float cameraNoise = intensity * 10;

        while(Time.time < endTime)
        {
            float normalizedTime = (Time.time - startTime) / shakeDuration;
            float offsetX = PerlinNoise(noiseSeed + cameraNoise * Time.time, 0);
            float offsetY = PerlinNoise(0, noiseSeed + cameraNoise * Time.time);

            Vector3 offset = new Vector2(offsetX, offsetY) * shakeCurve.Evaluate(normalizedTime) * intensity;
            transform.position += offset;
            yield return null;
        }
    }

    public static void LightShakeScreen()
    {
        ShakeScreen(instance.lightIntensity);
    }

    public static void HeavyShakeScreen()
    {
        ShakeScreen(instance.heavyIntensity);
    }
}
