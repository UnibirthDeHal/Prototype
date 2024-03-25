using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg1_Dragon_Move : IState
{
    private Control_Leg1 leg1;

    public Leg1_Dragon_Move(Control_Leg1 Leg1)
    {
        this.leg1 = Leg1;
    }

    public void Enter()
    {
        leg1.SetAnimation("Dragon_Move");
    }

    public void Execute()
    {
        // “ü—Í
        float move_input = Input.GetAxisRaw("Horizontal");

        // Œü‚«’²®
        if (move_input > 0 && leg1.player.dir == 4)
        {
            leg1.player.dir = 6;
            leg1.player.SetSpriteFlip(false);
        }
        if (move_input < 0 && leg1.player.dir == 6)
        {
            leg1.player.dir = 4;
            leg1.player.SetSpriteFlip(true);
        }

        // À•WˆÚ“®ŒvŽZ
        leg1.player.transform.position += new Vector3(move_input, 0, 0) * leg1.player.moveSpeed * Time.deltaTime;

        if (leg1.player.isjump == true)
        {
            leg1.ChangeState(new Leg1_Dragon_Jump(leg1));
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            leg1.ChangeState(new Leg1_Dragon_Idle(leg1));
        }

        if (leg1.nowstate == 0)
        {
            leg1.ChangeState(new Leg1_Human_Move(leg1));
        }
        else if (leg1.nowstate == 1)
        {
            //leg1.ChangeState(new Leg1_Dragon_Move(leg1));
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
