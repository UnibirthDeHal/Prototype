using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_State_Idle : IState
{
    private Control_Hand Hand;

    public Hand_State_Idle(Control_Hand Hand)
    {
        this.Hand = Hand;
    }

    public void Enter()
    {
        //変異状況管理から腕の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜腕待機")
        //    Head.SetAnimation("Hand(1)Idle");
        Debug.Log("人腕待機");
        Hand.SetAnimation("Hand(0)Idle");
    }

    public void Execute()
    {
        //PlayerがAttackStateに入ったら
        //【状態遷移】Attack状態に
        //Hand.ChangeState(new Hand_State_SubAttack(Hand));
    }

    public void Exit()
    {

    }
}
