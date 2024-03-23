using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Head_Human_Idle : IState
{
    private Control_Head head;

    public Head_Human_Idle(Control_Head Head)
    {
        this.head = Head;
    }

    public void Enter()
    {
        head.SetAnimation("Human_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            head.ChangeState(new Head_Dragon_Idle(head));   
        }
    }

    public void Exit()
    {

    }
}
