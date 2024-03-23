using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg2_Dragon_SubAttack : IState
{
    private Control_Leg2 leg2;

    public Leg2_Dragon_SubAttack(Control_Leg2 Leg2)
    {
        this.leg2 = Leg2;
    }

    public void Enter()
    {
        leg2.SetAnimation("Dragon_SubAttack");
    }

    public void Execute()
    {
        if (leg2.AnimationFinished("Dragon_SubAttack"))
        {
            leg2.ChangeState(new Leg2_Dragon_Idle(leg2));   
        }
    }

    public void Exit()
    {

    }
}
