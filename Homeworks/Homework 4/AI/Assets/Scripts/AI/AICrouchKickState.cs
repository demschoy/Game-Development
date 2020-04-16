using UnityEngine;
using static UnityEngine.Mathf;

public class AICrouchKickState : StateMachineBehaviour
{
    private Animator animator;
    private MovementController movementController;
    private GameObject hitBox;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        hitBox = animator.transform.GetChild(2).gameObject;
        hitBox.SetActive(true);

        float crouchKickDirectionToPlayer = Sign(animator.transform.localScale.x);
        movementController = animator.GetComponent<MovementController>();
        movementController.SetHorizontalMoveDirection(crouchKickDirectionToPlayer);
        movementController.OnCrouchEnded += ResetAnimationState;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movementController.OnCrouchEnded -= ResetAnimationState;
        hitBox.SetActive(false);
    }

    private void ResetAnimationState()
    {
        animator.SetTrigger("StoodUp");
    }
}
