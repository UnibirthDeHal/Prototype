using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_Dragon_Idle : IState
{
    private Control_Body body;

    public Body_Dragon_Idle(Control_Body Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Dragon_Idle");
    }

    public void Execute()
    {
        if (body.nowstate == 0)
        {
            body.ChangeState(new Body_Human_Idle(body));
        }
        else if (body.nowstate == 1)
        {
            //body.ChangeState(new Body_Dragon_Idle(body));
        }
        else if (body.nowstate == 2)
        {
            body.ChangeState(new Body_Fish_Idle(body));
        }
        else
        {
            body.nowstate = 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            body.ChangeState(new Body_Fish_Idle(body));
        }
    }

    public void Exit()
    {

    }
}
