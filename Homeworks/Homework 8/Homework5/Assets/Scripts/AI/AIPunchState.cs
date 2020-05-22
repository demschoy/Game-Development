using UnityEngine;
using static AudioManager;

public class AIPunchState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		MovementController movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		PlayHitAudio();
	}
}
