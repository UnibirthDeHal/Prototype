using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_Dragon_SubAttack : IState
{
    private Control_Hand hand;

    public Hand_Dragon_SubAttack(Control_Hand Hand)
    {
        this.hand = Hand;
    }

    public void Enter()
    {
        hand.SetAnimation("Dragon_SubAttack");
        hand.GetComponent<BoxCollider>().enabled = true;
    }

    public void Execute()
    {
        if (hand.AnimationFinished("Dragon_SubAttack"))
        {
            hand.GetComponent<BoxCollider>().enabled = false;
            hand.ChangeState(new Hand_Dragon_Idle(hand));
        }
    }

    public void Exit()
    {

    }
}
