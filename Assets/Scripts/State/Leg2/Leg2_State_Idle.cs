using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg2_State_Idle : IState
{
    private Control_Leg2 Leg2;

    public Leg2_State_Idle(Control_Leg2 Leg2)
    {
        this.Leg2 = Leg2;
    }

    public void Enter()
    {
        //変異状況管理から尻尾の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜尻尾待機")
        //    Leg2.SetAnimation("Leg2(1)Idle");
        Debug.Log("人尻尾なし");
        Leg2.SetAnimation("Leg2(0)Idle");
    }

    public void Execute()
    {
        //QとEで尻尾を選択している状態(選択できるだから必ず尻尾がある状態)かつPlayerがSubAttackStateに入ったら
        //【状態遷移】SubAttack状態に
        //Leg2.ChangeState(new Leg2_State_SubAttack(Leg2));
    }

    public void Exit()
    {

    }
}
