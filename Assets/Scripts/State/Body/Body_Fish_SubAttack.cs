using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_Fish_SubAttack : IState
{
    private Control_Body body;

    public Body_Fish_SubAttack(Control_Body Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Fish_SubAttack");
    }

    public void Execute()
    {
        if (body.AnimationFinished("Fish_SubAttack")) 
        {
            body.ChangeState(new Body_Fish_Idle(body));
        }
    }

    public void Exit()
    {

    }
}
