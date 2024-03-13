using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_State_Attack : IState
{
    private ControlHand Hand;

    public Hand_State_Attack(ControlHand Hand)
    {
        this.Hand = Hand;
    }

    public void Enter()
    {
        //変異状況管理から腕の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜腕攻撃")
        //    Head.SetAnimation("Hand(1)Attack");
        Debug.Log("人腕攻撃");
        Hand.SetAnimation("Hand(0)Attack");
    }

    public void Execute()
    {
        //Attackアニメーションが終わったら
        //【状態遷移】Idle状態に
        //Hand.ChangeState(new Hand_State_Idle(Hand));
    }

    public void Exit()
    {

    }
}
