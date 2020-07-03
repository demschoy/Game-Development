using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 25f;
    [SerializeField]
    private Rigidbody2D bullet = null;
    int interval = 2;
    float nextTime = 0;
    
    void Update()
    {
        if (Time.time >= nextTime) 
        {
            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            bulletInstance.velocity = transform.forward * maxSpeed;
            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            nextTime += interval;
        } 
    }
}
