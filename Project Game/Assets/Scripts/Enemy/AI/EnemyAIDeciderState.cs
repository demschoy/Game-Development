using UnityEngine;

public class EnemyAIDeciderState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float randomValue = Random.value;
        if(randomValue <= 0.5)
        {
            animator.SetTrigger("ShouldWalk");
        }
        else if(randomValue > 0.5 && randomValue <= 1)
        {
            animator.SetTrigger("ShouldAttack");
        }
    }

}
