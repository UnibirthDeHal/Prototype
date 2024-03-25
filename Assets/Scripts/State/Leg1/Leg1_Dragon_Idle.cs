using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg1_Dragon_Idle : IState
{
    private Control_Leg1 leg1;

    public Leg1_Dragon_Idle(Control_Leg1 Leg1)
    {
        this.leg1 = Leg1;
    }

    public void Enter()
    {
        leg1.SetAnimation("Dragon_Idle");
    }

    public void Execute()
    {
        //�y��ԑJ�ځzMove��Ԃ�
        if (leg1.player.isjump == true)
        {
            leg1.ChangeState(new Leg1_Dragon_Jump(leg1));
        }

        else if(Input.GetAxisRaw("Horizontal") != 0)
        {
            leg1.ChangeState(new Leg1_Dragon_Move(leg1));
        }

        //else if (Input.GetKeyDown(KeyCode.V))
        //{
        //    leg1.ChangeState(new Leg1_Human_Idle(leg1));
        //}

        if (leg1.nowstate == 0)
        {
            leg1.ChangeState(new Leg1_Human_Idle(leg1));
        }
        else if (leg1.nowstate == 1)
        {
            //leg1.ChangeState(new Leg1_Dragon_Idle(leg1));
        }
        else
        {
            leg1.nowstate = 1;
        }
    }

    public void Exit()
    {

    }
}
