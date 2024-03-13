using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Head_State_SubAttack : IState
{
    private ControlHead Head;

    public Head_State_SubAttack(ControlHead Head)
    {
        this.Head = Head;
    }

    public void Enter()
    {
        Debug.Log("竜頭攻撃");
        Head.SetAnimation("Head(1)Attack");
    }

    public void Execute()
    {
        //SubAttackアニメーションが終わったら
        //【状態遷移】Idle状態に
        //Head.ChangeState(new Head_State_Idle(Head));
    }

    public void Exit()
    {

    }
}
