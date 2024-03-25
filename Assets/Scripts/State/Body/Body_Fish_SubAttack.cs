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
        body.isAttacked = false;
    }

    public void Execute()
    {
        var state = body.animator.GetCurrentAnimatorStateInfo(0);

        if (body.isAttacked == false)
        {
            if (state.normalizedTime >= 0.7f)
            {
                body.GetComponent<BoxCollider>().enabled = true;
            }

            if (state.normalizedTime >= 0.9f)
            {
                body.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (body.AnimationFinished("Fish_SubAttack")) 
        {
            body.ChangeState(new Body_Fish_Idle(body));
        }
    }

    public void Exit()
    {

    }
}
