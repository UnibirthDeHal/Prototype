using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State_Enemy_Idle : IState
{
    private Control_Enemy enemy;

    public State_Enemy_Idle(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Idle 状態に入ったときの初期化などを行う
        enemy.idletimer = 0;
    }

    public void Execute()
    {
        enemy.idletimer += Time.deltaTime;

        // 一定範時間後Move状態に入る
        if (enemy.idletimer > enemy.endidletime)
        {
            enemy.ChangeState(new State_Enemy_Move(enemy));
        }

        // Idle 状態で毎フレーム実行される処理
    }

    public void Exit()
    {
        // Idle 状態から他の状態に遷移するときの終了処理
    }
}
