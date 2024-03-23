using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg2_Dragon_Idle : IState
{
    private Control_Leg2 leg2;

    public Leg2_Dragon_Idle(Control_Leg2 Leg2)
    {
        this.leg2 = Leg2;
    }

    public void Enter()
    {
        leg2.SetAnimation("Dragon_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            leg2.ChangeState(new Leg2_Fish_Idle(leg2));
        }

        else if (Input.GetKeyDown(KeyCode.H))
        {
            leg2.ChangeState(new Leg2_Dragon_SubAttack(leg2));
        }
    }

    public void Exit()
    {

    }
}
