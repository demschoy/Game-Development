using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    [Range(1, 4)]
    private int hitTarget = 2;

    public static event Action OnEnemyDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO - add more logic

        TakeDamage();
    }

    public void Die()
    {
        OnEnemyDeath?.Invoke();
    }
       
    private void TakeDamage()
    {
        hitTarget -= 1;
        if(hitTarget <= 0)
        {
            //TODO - add more effects 

            OnEnemyDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
