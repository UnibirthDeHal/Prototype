using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Head_Dragon_Idle : IState
{
    private Control_Head head;

    public Head_Dragon_Idle(Control_Head Head)
    {
        this.head = Head;
    }

    public void Enter()
    {
        head.SetAnimation("Dragon_Idle");
    }

    public void Execute()
    {
        if (head.nowstate == 0)
        {
            head.ChangeState(new Head_Human_Idle(head));
        }
        else if (head.nowstate == 1)
        {
            //head.ChangeState(new Head_Dragon_Idle(head));
        }
        else if (head.nowstate == 2)
        {
            head.ChangeState(new Head_Fish_Idle(head));
        }
        else
        {
            head.nowstate = 1;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            head.ChangeState(new Head_Fish_Idle(head));
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            head.ChangeState(new Head_Dragon_SubAttack(head));
        }
    }

    public void Exit()
    {

    }
}
