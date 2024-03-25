using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg2_Fish_SubAttack : IState
{
    private Control_Leg2 leg2;

    public Leg2_Fish_SubAttack(Control_Leg2 Leg2)
    {
        this.leg2 = Leg2;
    }

    public void Enter()
    {
        leg2.SetAnimation("Fish_SubAttack");
        leg2.isAttacked = false;
    }

    public void Execute()
    {
        var state = leg2.animator.GetCurrentAnimatorStateInfo(0);

        if (leg2.isAttacked == false)
        {
            if (state.normalizedTime >= 0.7f)
            {
                leg2.GetComponent<BoxCollider>().enabled = true;
            }

            if (state.normalizedTime >= 0.9f)
            {
                leg2.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (leg2.AnimationFinished("Fish_SubAttack"))
        {
            leg2.ChangeState(new Leg2_Fish_Idle(leg2));   
        }
    }

    public void Exit()
    {

    }

}
