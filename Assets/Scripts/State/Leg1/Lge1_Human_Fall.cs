using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg1_Human_Fall : IState
{
    private Control_Leg1 leg1;

    public Leg1_Human_Fall(Control_Leg1 Leg1)
    {
        this.leg1 = Leg1;
    }

    public void Enter()
    {
        leg1.SetAnimation("Human_Fall");
    }

    public void Execute()
    {
        //y๓ิJฺzIdle๓ิษ
        if (leg1.player.isfall == false)
        {
            leg1.ChangeState(new Leg1_Human_Idle(leg1));
        }
    }

    public void Exit()
    {

    }
}
