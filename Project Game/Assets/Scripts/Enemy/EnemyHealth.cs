using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    [Range(1, 4)]
    private int hitTarget = 2;

    private Animator animator = null;

    public static event Action OnEnemyDeath;
    public static event Action OnHitGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO - add more logic
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
        }
        if(collision.CompareTag("Ground"))
        {
            // OnHitGround?.Invoke();
 
        // lose life instead?
        }
    }

    public void GoingToDie()
    {
        //TODO - add more effects
    }

    public void Die()
    {
        Destroy(gameObject);
    }
       
    private void TakeDamage()
    {
        hitTarget -= 1;
        animator.SetTrigger("TookDamage");
        if(hitTarget <= 0)
        {
            //TODO - add more effects 
            animator.SetTrigger("Die");
            OnEnemyDeath?.Invoke();
        }
    }
}
