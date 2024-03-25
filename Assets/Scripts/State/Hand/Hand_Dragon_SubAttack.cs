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

        if (hand.AnimationFinished("Dragon_SubAttack"))
        {
            hand.ChangeState(new Hand_Dragon_Idle(hand));
        }
    }

    public void Exit()
    {

    }
}
