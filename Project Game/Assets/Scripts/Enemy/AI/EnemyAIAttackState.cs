using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAttackState : StateMachineBehaviour
{
    private GameObject bullet = null;
    private Animator bulletAnimator = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bullet = animator.GetComponentInParent<Transform>().gameObject;
        Debug.Log(bullet);
        bullet.SetActive(true);
        bulletAnimator = bullet.GetComponent<Animator>();
    }
}
