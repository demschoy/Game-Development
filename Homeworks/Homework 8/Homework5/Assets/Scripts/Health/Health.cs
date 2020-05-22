using System;
using UnityEngine;
using static UnityEngine.Mathf;
using static AudioManager;
using static ScreenShaker;

public class Health : MonoBehaviour {

    public static readonly int maxHealth = 100;

    [SerializeField]
    private int health = maxHealth;

    public int HP {
        get { return health; }
        set {
            health = Clamp(value, 0, maxHealth);
        }
    }

    private Animator animator;
    public GameObject cross;

    public event Action<int> OnDamageTaken;
    public static event Action<Vector3, Vector3> OnTakeDamage;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public int GetHealth() {
        return health;
    }

    public void SpawnCross() {
        Vector2 spawnPosition = new Vector2 {
            x = transform.position.x,
            y = -0.1f
        };
        Instantiate(cross, spawnPosition, Quaternion.identity);
    }

    public void Die() {
        PlayDieAudio();
        OnTakeDamage.Invoke(transform.position, Vector3.one);
        Destroy(gameObject);
    }

    public void TakeDamage() {
        int damage = 10;
        health = Max(health - damage, 0);
        animator.SetInteger("Health", health);
        animator.SetTrigger("TookDamage");
        OnDamageTaken?.Invoke(health);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.parent != transform
            && collision.gameObject.CompareTag("Hitbox")) {

            TakeDamage();
            PlayHurtAudio();
            OnTakeDamage?.Invoke(transform.position, Vector3.zero);
        }
    }
}