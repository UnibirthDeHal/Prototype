using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Jump : IState
{
    private ControlLeg1 Leg1;

    public Leg1_State_Jump(ControlLeg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //変異状況管理から足の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜足ジャンプ")
        //    Leg1.SetAnimation("Leg1(1)Jump");
        Debug.Log("人足ジャンプ");
        Leg1.SetAnimation("Leg1(1)Jump");
    }

    public void Execute()
    {
        //PlayerがFallStateに入ったら
        //【状態遷移】Fall状態に
        //Leg1.ChangeState(new Leg1_State_Fall(Leg1));
    }

    public void Exit()
    {

    }
}
