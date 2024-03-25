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
        hand.isAttacked = false;
    }

    public void Execute()
    {
        var state = hand.animator.GetCurrentAnimatorStateInfo(0);

        if (hand.isAttacked == false)
        {
            if (state.normalizedTime >= 0.7f)
            {
                hand.GetComponent<BoxCollider>().enabled = true;
            }

            if (state.normalizedTime >= 0.9f)
            {
                hand.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (hand.AnimationFinished("Human_SubAttack"))
        {
            hand.ChangeState(new Hand_Human_Idle(hand));
        }
    }

    public void Exit()
    {

    }
}
