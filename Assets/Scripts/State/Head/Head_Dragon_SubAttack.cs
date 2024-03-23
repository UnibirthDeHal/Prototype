using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    }

    public void Execute()
    {
        if (head.AnimationFinished("Dragon_Fire"))
        {
            head.ChangeState(new Head_Dragon_Idle(head));
        }
    }

    public void Exit()
    {

    }
}
