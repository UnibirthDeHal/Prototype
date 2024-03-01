using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State_Enemy_Idle : MonoBehaviour
{
    private Control_Enemy enemy;

    public State_Enemy_Idle(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Idle 状態に入ったときの初期化などを行う
    }

    public void Execute()
    {
        // プレイヤーの位置を取得
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPosition = playerTransform.position;

        // エネミーとプレイヤーの距離を計算
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerPosition);

        // 一定範囲以下になった場合、Chase 状態に遷移
        if (distanceToPlayer < 5f) // 5fは適切な範囲の例です
        {
            enemy.ChangeState(new State_Enemy_Chase(enemy));
        }

        // Idle 状態で毎フレーム実行される処理
    }

    public void Exit()
    {
        // Idle 状態から他の状態に遷移するときの終了処理
    }
}
