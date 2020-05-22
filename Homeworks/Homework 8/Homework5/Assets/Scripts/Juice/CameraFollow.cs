using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraFollow : MonoBehaviour
{
    private Transform player = null;
    private Transform scene = null;
    private Vector3 offset;
    [SerializeField]
    [Range(0, 1)]
    private float smoothSpeed = 0.01f; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        scene = GameObject.FindWithTag("Scene").transform;
        offset = transform.position - scene.position;
    }

    void LateUpdate()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 position = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothSpeed);
        transform.LookAt(scene);
    }
}
