using UnityEngine;

public class OnPlayerAttacked : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
        animator.SetTrigger("Dead");
    }

}
