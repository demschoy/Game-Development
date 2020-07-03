using UnityEngine;
using static UnityEngine.Mathf;

public class EnemyAIWalkState : StateMachineBehaviour
{
    private Transform player = null;   
    private EnemyMovement enemyMovement;
    private float movementTreshold = 0.01f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject[] playerGameObjects = GameObject.FindGameObjectsWithTag("Player");
        if(playerGameObjects.Length == 0)
        {
            Debug.LogError("No Object with Player tag found.");
        }
        else
        {
            int playerID = FindClosestPlayer(playerGameObjects, animator);
            Debug.Log(playerID);
            player = playerGameObjects[playerID].transform;
        }

        enemyMovement = animator.GetComponent<EnemyMovement>();
    }

    private int FindClosestPlayer(GameObject[] players, Animator animator)
    {
        if(players.Length != 2)
        {
            Debug.LogError("More Than 2 players!");
            return -1;
        }
        Debug.Log(players.Length);
        for(int id = 0; id < players.Length; id++)
        {
            Transform player = players[id].transform;
            if (player.position.x >= animator.transform.position.x && player.position.x <= animator.transform.position.x)
            {
                return id;
            };
        }

        return 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 vectorToPlayer = player.position - animator.transform.position;
        float distanceToPlayer = vectorToPlayer.magnitude;
        float moveDirection = Sign(vectorToPlayer.y);

        if(distanceToPlayer > movementTreshold)
        {
            enemyMovement.SetMoveDirection(moveDirection);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
