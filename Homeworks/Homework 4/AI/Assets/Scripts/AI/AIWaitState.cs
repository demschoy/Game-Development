using UnityEngine;
public class AIWaitState : StateMachineBehaviour {

	private MovementController movementController;
	private Transform player;
	private Animator animator;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.animator = animator;
		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		player = GameObject.FindWithTag("Player").transform;
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float directionToPlayer = player.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);

		detectEnemyPunch();
	}

	private void detectEnemyPunch()
	{
		movementController.OnCrouch += SetCrouchState;
	}

	private void SetCrouchState()
	{
		animator.SetTrigger("ShouldCrouch");
		movementController.dodgeAfterPunch = true;
	}
}
