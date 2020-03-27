using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, 0);
    [SerializeField]
    [Range(0.1f, 0.5f)]
    private float smoothedSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 position = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothedSpeed);
        transform.LookAt(target);
    }
}
