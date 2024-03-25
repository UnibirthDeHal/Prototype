using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg1_Dragon_Jump : IState
{
    private Control_Leg1 leg1;

    public Leg1_Dragon_Jump(Control_Leg1 Leg1)
    {
        this.leg1 = Leg1;
    }

    public void Enter()
    {
        leg1.SetAnimation("Dragon_Jump");
    }

    public void Execute()
    {
        //y๓ิJฺzIdle๓ิษ
        if (leg1.player.isfall == true)
        {
            leg1.ChangeState(new Leg1_Dragon_Fall(leg1));
        }

        else if (leg1.player.isjump == false)
        {
            leg1.ChangeState(new Leg1_Dragon_Idle(leg1));
        }
    }

    public void Exit()
    {

    }
}
