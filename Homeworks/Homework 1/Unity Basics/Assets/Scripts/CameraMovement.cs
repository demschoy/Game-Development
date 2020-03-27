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
    private float smoothedSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 position = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothedSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
