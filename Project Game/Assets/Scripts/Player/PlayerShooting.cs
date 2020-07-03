using UnityEngine;

using static Controllers;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 25f;
    [SerializeField]
    private Rigidbody2D firstBullet = null;
    [SerializeField]
    private Rigidbody2D secondBullet = null;
    [SerializeField]
    private GameObject player1 = null;
    [SerializeField]
    private GameObject player2 = null;

    void Update()
    {
        if (Input.GetKeyDown(FirstPlayerShootKey))
        {
            Shoot(player1, firstBullet);
        }

        if (Input.GetKeyDown(SecondPlayerShootKey))
        {
            Shoot(player2, secondBullet);
        }
    }

    private void Shoot(GameObject player, Rigidbody2D bullet)
    {
        Rigidbody2D bulletInstance = Instantiate(bullet, player.transform.position, player.transform.rotation) as Rigidbody2D;
        bulletInstance.velocity = player.transform.forward * maxSpeed;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
}
