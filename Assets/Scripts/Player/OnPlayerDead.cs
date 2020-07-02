using System;
using UnityEngine;

public class OnPlayerDead : StateMachineBehaviour
{
    public static Action OnPlayerDeadEvent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnPlayerDeadEvent?.Invoke();
    }
}
