using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int maxHitsToTake = 5;

    [SerializeField]
    private GameObject lives = null;

    public int LivesLeft { get; private set;  } = 3;
    public int HitsLeft { get; private set; } = 5;
    
    private Animator animator;
    private Animator livesAnimator;

    public event Action OnDamageTaken;

    public void Start()
    {
        HitsLeft = maxHitsToTake;

        animator = GetComponent<Animator>();
        livesAnimator = lives.GetComponent<Animator>();

        animator.SetInteger("Health", HitsLeft);
    }

    public int MaxHitsToTake()
    {
        return maxHitsToTake;
    }

    public void TakeDamage()
    {
        HitsLeft -= 1;
        if(HitsLeft <= 0)
        {
            LoseLife();
        }
        else
        {
            animator.SetInteger("Health", HitsLeft);
            animator.SetTrigger("TookDamage");
            livesAnimator.SetTrigger("TookDamage");
        }
        OnDamageTaken?.Invoke();
    }

    public void LoseLife()
    {
        LivesLeft -= 1;
        animator.SetTrigger("LostLife");
        livesAnimator.SetTrigger("LostLife");

        if (LivesLeft <= 0)
        {
            Die();
        }
        else
        {
            HitsLeft = maxHitsToTake;
            animator.SetInteger("Health", HitsLeft);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO - add logic
        if ("shooting" == "shoot")
        {
            TakeDamage();
            OnDamageTaken?.Invoke();
        }
        if("fallenToTheGround" == "fallen")
        {
            LoseLife();
            OnDamageTaken?.Invoke();
        }
    }

}
