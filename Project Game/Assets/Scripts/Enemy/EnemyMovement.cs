using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 4)]
    private float moveSpeed = 2f;

    private Rigidbody2D rigidBody = null;
    private Vector2 velocity = Vector3.zero;
    public Vector2 Velocity { get => velocity; }
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 newPosition = new Vector2(velocity.x * moveSpeed, velocity.y) * Time.deltaTime * rigidBody.position;
        rigidBody.MovePosition(newPosition);
    }

    public void SetMoveDirection(float moveAmount)
    {
        velocity.y = moveAmount;
    }
}
