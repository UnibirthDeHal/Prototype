using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Fall : IState
{
    private Control_Leg1 Leg1;

    public Leg1_State_Fall(Control_Leg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //変異状況管理から足の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜足落下")
        //    Leg1.SetAnimation("Leg1(1)Fall");
        Debug.Log("人足落下");
        Leg1.SetAnimation("Leg1(1)Fall");
    }

    public void Execute()
    {
        //PlayerがIdleStateに入ったら
        //【状態遷移】Idle状態に
        //Leg1.ChangeState(new Leg1_State_idle(Leg1));
    }

    public void Exit()
    {

    }
}
