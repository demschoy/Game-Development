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

    private float movementThreshold = 0.01f;
    private float smoothMovement = 0.15f;

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
        if (!Input.GetKey(FirstPlayerRight) && Input.GetKey(FirstPlayerLeft) && firstPlayer.transform.position.x >= -11)
        {
            Move(firstPlayer, firstPlayerAnimator, Vector3.left * smoothMovement); 
        }
        else if(!Input.GetKey(FirstPlayerLeft) && Input.GetKey(FirstPlayerRight) && firstPlayer.transform.position.x <= -2.5)
        {
            Move(firstPlayer, firstPlayerAnimator, Vector3.right * smoothMovement);
        }
        else
        {
            NotMoving(firstPlayerAnimator);        
        }

        if (!Input.GetKey(SecondPlayerRight) && Input.GetKey(SecondPlayerLeft) && secondPlayer.transform.position.x >= -1.2)
        {
            Move(secondPlayer, secondPlayerAnimator, Vector3.left * smoothMovement);
        }
        else if (!Input.GetKey(SecondPlayerLeft) && Input.GetKey(SecondPlayerRight) && secondPlayer.transform.position.x <= 7.9)
        {
            Move(secondPlayer, secondPlayerAnimator, Vector3.right * smoothMovement);
        }
        else
        {
            NotMoving(secondPlayerAnimator);
        }
    }

    private void Move(GameObject player, Animator animator, Vector3 direction)
    {
        animator.SetFloat("HorizontalMovement", Abs(direction.x));

        if(Abs(direction.x) > movementThreshold)
        {
            player.transform.localScale = new Vector3(3 * Sign(direction.x), 3, 1);
        }

        player.transform.position += direction * speed * Time.deltaTime;

        OnPlayerMove?.Invoke();
    }

    private void NotMoving(Animator animator)
    {
        animator.SetFloat("HorizontalMovement", Vector3.zero.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
    }
}