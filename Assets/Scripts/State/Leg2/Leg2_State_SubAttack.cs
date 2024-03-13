using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg2_State_SubAttack : IState
{
    private ControlLeg2 Leg2;

    public Leg2_State_SubAttack(ControlLeg2 Leg2)
    {
        this.Leg2 = Leg2;
    }

    public void Enter()
    {
        //変異状況管理から尻尾の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜尻尾攻撃")
        //    Head.SetAnimation("Leg2(1)SubAttack");
        Debug.Log("魚尻尾攻撃");
        Leg2.SetAnimation("Leg2(2)SubAttack");
    }

    public void Execute()
    {
        //SubAttackアニメーションが終わったら
        //【状態遷移】Idle状態に
        //Leg2.ChangeState(new Leg2_State_Idle(Leg2));
    }

    public void Exit()
    {

    }
}