using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_Human_SubAttack : IState
{
    private Control_Hand hand;

    public Hand_Human_SubAttack(Control_Hand Hand)
    {
        this.hand = Hand;
    }

    public void Enter()
    {
        hand.SetAnimation("Human_SubAttack");
        hand.GetComponent<BoxCollider>().enabled = true;
    }

    public void Execute()
    {
        if (hand.AnimationFinished("Human_SubAttack"))
        {
            hand.GetComponent<BoxCollider>().enabled = false;
            hand.ChangeState(new Hand_Human_Idle(hand));
        }
    }

    public void Exit()
    {

    }
}
