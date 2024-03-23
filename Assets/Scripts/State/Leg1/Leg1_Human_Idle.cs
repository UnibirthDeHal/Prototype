using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg1_Human_Idle : IState
{
    private Control_Leg1 leg1;

    public Leg1_Human_Idle(Control_Leg1 Leg1)
    {
        this.leg1 = Leg1;
    }

    public void Enter()
    {
        leg1.SetAnimation("Human_Idle");
    }

    public void Execute()
    {
        //ÅyèÛë‘ëJà⁄ÅzMoveèÛë‘Ç…
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            leg1.ChangeState(new Leg1_Human_Move(leg1));
        }

        else if (Input.GetKeyDown(KeyCode.V))
        {
            leg1.ChangeState(new Leg1_Dragon_Idle(leg1));   
        }
    }

    public void Exit()
    {

    }
}
