using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
     
        if(gameObject.activeSelf)
        {
            animator.SetBool("IsVisible", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("IsGrounded", true);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
