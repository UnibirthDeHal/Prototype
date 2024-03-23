using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_Dragon_Idle : IState
{
    private Control_Hand hand;

    public Hand_Dragon_Idle(Control_Hand Hand)
    {
        this.hand = Hand;
    }

    public void Enter()
    {
        hand.SetAnimation("Dragon_Idle");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            hand.ChangeState(new Hand_Human_Idle(hand));
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            hand.ChangeState(new Hand_Dragon_SubAttack(hand));
        }
    }

    public void Exit()
    {

    }
}
