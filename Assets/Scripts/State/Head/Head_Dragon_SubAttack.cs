using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Head_Dragon_SubAttack : IState
{
    private Control_Head head;

    public Head_Dragon_SubAttack(Control_Head Head)
    {
        this.head = Head;
    }

    public void Enter()
    {
        head.SetAnimation("Dragon_Fire");
        head.isAttacked = false;
    }

    public void Execute()
    {
        var state = head.animator.GetCurrentAnimatorStateInfo(0);

        if (head.isAttacked == false)
        {
            if (state.normalizedTime >= 0.7f)
            {
                head.GetComponent<BoxCollider>().enabled = true;
            }

            if (state.normalizedTime >= 0.9f)
            {
                head.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (head.AnimationFinished("Dragon_Fire"))
        {
            head.ChangeState(new Head_Dragon_Idle(head));
        }
    }

    public void Exit()
    {

    }
}
