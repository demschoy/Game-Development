using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    private Vector3 offset;
    [SerializeField]
    private float smoothedSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, smoothedSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }
}
