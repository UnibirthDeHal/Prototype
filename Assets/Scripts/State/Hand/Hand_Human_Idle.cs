using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_Human_Idle : IState
{
    private Control_Hand hand;

    public Hand_Human_Idle(Control_Hand Hand)
    {
        this.hand = Hand;
    }

    public void Enter()
    {
        hand.SetAnimation("Human_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            hand.ChangeState(new Hand_Dragon_Idle(hand));
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            hand.ChangeState(new Hand_Human_SubAttack(hand));
        }
    }

    public void Exit()
    {

    }
}
