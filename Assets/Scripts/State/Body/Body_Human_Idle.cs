using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_Human_Idle : IState
{
    private Control_Body body;

    public Body_Human_Idle(Control_Body Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Human_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            body.ChangeState(new Body_Fish_Idle(body));
        }
    }

    public void Exit()
    {

    }
}
