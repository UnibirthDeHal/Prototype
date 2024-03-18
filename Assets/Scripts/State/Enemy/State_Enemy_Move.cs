using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
//using UnityEngine.Scripting;

//[ExtensionOfNativeClass]
public class State_Enemy_Move : IState
{
    private Control_Enemy enemy;
    private float StartPosX;
    private float LeftPosX;
    private float RightPosX;
    private float dir = -1.0f;
    private int count;
    private int countMax = 2;

    public State_Enemy_Move(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Move 状態に入ったときの初期化などを行う
        count = 0;
        StartPosX = enemy.transform.position.x;
        LeftPosX = enemy.transform.position.x - (enemy.moverange / 2);
        RightPosX = enemy.transform.position.x + (enemy.moverange / 2);
    }

    public void Execute()
    {
        //移動範囲に辿ったら逆戻り
        if (enemy.transform.position.x <= LeftPosX)
        {
            dir = 1.0f;
            count++;
        }
        else if (enemy.transform.position.x >= RightPosX)
        {
            dir = -1.0f;
            count++;
        }

        //テクスチャーの向きを変わる
        if (dir < 0)
        {
            enemy.spriteRenderer.flipX = false;
        }
        else if (dir > 0)
        {
            enemy.spriteRenderer.flipX = true;
        }

        //移動
        enemy.transform.position += new Vector3(dir, 0, 0) * enemy.moveSpeed * Time.deltaTime;

        //一回りしたらIdle状態に入る(Bugあり)
        //if ((count >= countMax) && ((enemy.transform.position.x >= (StartPosX-0.001f) || (enemy.transform.position.x <= (StartPosX + 0.001f)))))
        //{
        //    enemy.ChangeState(new State_Enemy_Idle(enemy));
        //}

        // Move 状態で毎フレーム実行される処理
    }

    public void Exit()
    {
        // Move 状態から他の状態に遷移するときの終了処理
    }
}

