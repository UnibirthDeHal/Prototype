using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Head_Fish_Idle : IState
{
    private Control_Head head;

    public Head_Fish_Idle(Control_Head Head)
    {
        this.head = Head;
    }

    public void Enter()
    {
        head.SetAnimation("Fish_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            head.ChangeState(new Head_Human_Idle(head));
        }
    }

    public void Exit()
    {

    }
}
