using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_State_Idle : IState
{
    private Control_Player player;

    public Player_State_Idle(Control_Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        //Debug.Log("待機状態に入った");
        player.SetAnimation("Idle");
    }

    public void Execute()
    {

        //【状態遷移】Move状態に
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            player.ChangeState(new Player_State_Move(player));
        }


        if (Input.GetButtonDown("Jump"))     
        {
            player.ChangeState(new Player_State_Jump(player));
        }
    }

    public void Exit()
    {

    }
}
