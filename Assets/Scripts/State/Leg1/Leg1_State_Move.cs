using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Move : IState
{
    private Control_Leg1 Leg1;

    public Leg1_State_Move(Control_Leg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //変異状況管理から足の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜足移動")
        //    Leg1.SetAnimation("Leg1(1)Move");
        Debug.Log("人足移動");
        Leg1.SetAnimation("Leg1(1)Move");
    }

    public void Execute()
    {
        //PlayerがIdleState/JumpStateに入ったら
        //【状態遷移】Move状態に
        //Leg1.ChangeState(new Leg1_State_Idle(Leg1));
        //【状態遷移】Jump状態に
        //Leg1.ChangeState(new Leg1_State_Jump(Leg1));
    }

    public void Exit()
    {

    }
}
