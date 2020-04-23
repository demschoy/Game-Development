﻿using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	[SerializeField]
	private HealthBar healthBar;

	private Animator animator;
	public GameObject cross;

	void Start() {
		animator = GetComponent<Animator>();
		healthBar.SetMaximumHealthValue(health);
	}

	public void SpawnCross() {
		Vector2 spawnPosition = new Vector2 {
			x = transform.position.x,
			y = -0.1f
		};
		Instantiate(cross, spawnPosition, Quaternion.identity);
	}

	public void Die() {
		Destroy(gameObject);
	}

	public void TakeDamage() {
		int damage = 10;
		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");

		healthBar.SetHealth(health);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		MovementController movementController = gameObject.GetComponent<MovementController>();
		if (collision.transform.parent != transform
			&& (collision.gameObject.CompareTag("Hitbox") || collision.gameObject.CompareTag("PunchHitbox")))  {

			TakeDamage();
		}
	}
}
