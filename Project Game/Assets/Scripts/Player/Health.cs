 using System;
using UnityEditor.UIElements;
using UnityEngine;
using static AudioManager;

public class Health : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int maxHitsToTake = 5;
    public int MaxHitsToTake { get => maxHitsToTake; }

    [SerializeField]
    private GameObject lives = null;

    public int LivesLeft { get; private set;  } = 3;
    public int HitsLeft { get; private set; } = 5;
    
    private Animator animator;
    private Animator livesAnimator;

    public event Action<int> OnDamageTaken;
    public static event Action<Vector3, Vector3> OnTakeDamage;
    public static event Action OnPlayerDeath;

    public void Start()
    {
        HitsLeft = maxHitsToTake;

        animator = GetComponent<Animator>();
        livesAnimator = lives.GetComponent<Animator>();

        animator.SetInteger("Health", HitsLeft);
    }

    public void TakeDamage()
    {
        HitsLeft -= 1;
        if(HitsLeft <= 0)       
        {
            LoseLife();
            OnTakeDamage?.Invoke(transform.position, Vector3.one);
        }
        else
        {
            animator.SetInteger("Health", HitsLeft);
            animator.SetTrigger("TookDamage");
            OnDamageTaken?.Invoke(HitsLeft);
        }
    }

    public void LoseLife()
    {
        LivesLeft -= 1;
        animator.SetTrigger("LostLife");
        livesAnimator.SetTrigger("LostLife");
        
        if (LivesLeft <= 0)
        {
            OnDamageTaken?.Invoke(HitsLeft);
            Die();
        }
        else
        {
            HitsLeft = maxHitsToTake;
            animator.SetInteger("Health", HitsLeft);
            OnDamageTaken?.Invoke(HitsLeft);
        }
    }

    public void Die()
    {
        PlayDeathSound();
        OnTakeDamage?.Invoke(transform.position, Vector3.one);
        OnPlayerDeath?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO - add further logic
        if (collision.CompareTag("EnemyBullet"))
        {
            PlayHurtSound();
            OnTakeDamage.Invoke(transform.position, Vector3.zero);
            TakeDamage();
        }

         if (collision.CompareTag("Enemy"))
        {
          LoseLife();
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnHitGround += LoseLife;
    }

    private void OnDisable()
    {
        EnemyHealth.OnHitGround -= LoseLife;
    }
}
