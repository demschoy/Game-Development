using UnityEngine;
using static StateMachineUtil;
public class AICrouchState : StateMachineBehaviour
{
    private MovementController movementController;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movementController = animator.GetComponent<MovementController>();
        movementController.SetHorizontalMoveDirection(0);
        movementController.Crouch();

        Transform player = GameObject.FindWithTag("Player").transform;
        float distanceDirectionToPlayer = player.position.x - animator.transform.position.x;
        movementController.TurnTowards(distanceDirectionToPlayer);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        float delay = 0.5f;
        DoWithDelay(delay, () => animator.SetTrigger("ShouldCrouchKick"));
    }
}
