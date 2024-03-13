using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Head_State_Idle : IState
{
    private ControlHead Head;

    public Head_State_Idle(ControlHead Head)
    {
        this.Head = Head;
    }

    public void Enter()
    {
        //変異状況管理から頭の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜頭待機")
        //    Head.SetAnimation("Head(1)Idle");
        Debug.Log("人頭待機");
        Head.SetAnimation("Head(0)Idle");
    }

    public void Execute()
    {
        //QとEで頭を選択している状態(選択できるだから必ず竜頭になっている)かつPlayerがSubAttackStateに入ったら
        //【状態遷移】SubAttack状態に
        //Head.ChangeState(new Head_State_SubAttack(Head));
    }

    public void Exit()
    {

    }
}
