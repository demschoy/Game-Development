using System;
using UnityEngine;
using static UnityEngine.Mathf;

using static Controllers;

using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPlayer = null;

    [SerializeField]
    private GameObject secondPlayer = null;

    [SerializeField]
    private float speed = 20;
    
    private Vector3 velocity = Vector3.zero;
    private Animator firstPlayerAnimator;
    private Animator secondPlayerAnimator;

    public static event Action OnPlayerMove;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        firstPlayerAnimator = firstPlayer.GetComponent<Animator>();
        secondPlayerAnimator = secondPlayer.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(FirstPlayerLeft) || Input.GetKey(FirstPlayerRight))
        {
            Move(firstPlayer, firstPlayerAnimator);
        }
        if (Input.GetKey(SecondPlayerLeft) || Input.GetKey(SecondPlayerRight))
        {

            Move(secondPlayer, secondPlayerAnimator);
        }
    }

    private void Move(GameObject player, Animator animator)
    {
            velocity.x = Input.GetAxis("Horizontal");
            animator.SetFloat("HorizontalMovement", Abs(velocity.x));

            player.transform.position += velocity * speed * Time.deltaTime;

            OnPlayerMove?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
    }
}