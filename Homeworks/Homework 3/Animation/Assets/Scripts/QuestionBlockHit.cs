using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockHit : MonoBehaviour
{
    [SerializeField]
    private GameObject mushroom = null;
    private bool isHit = false;
    private Animator mushroomAnimator;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mushroomAnimator = mushroom.GetComponent<Animator>();
        mushroom.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!isHit)
            {
                isHit = true;
                gameObject.tag = "Block";
                animator.SetBool("IsHit", isHit);
                mushroom.SetActive(true);
            }
        }
    }
}
