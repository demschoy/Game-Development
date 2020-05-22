using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

	private Animator animator = null;
	
	public int GetHealth()
	{
		return health;
	}

	public void TakeDamage()
	{
		int damage = 10;
		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.parent != transform && collision.gameObject.CompareTag("Hitbox"))
		{
			TakeDamage();
		}
	}
}
