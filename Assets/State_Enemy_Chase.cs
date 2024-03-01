using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State_Enemy_Chase : IState
{
    private Control_Enemy enemy;

    public State_Enemy_Chase(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Chase 状態に入ったときの初期化などを行う
    }

    public void Execute()
    {
        // プレイヤーの位置を取得
        Vector3 playerPosition = /* プレイヤーの位置を取得するコードを追加 */;

        // プレイヤーを追従する処理
        ChasePlayer(playerPosition);

        // Chase 状態で毎フレーム実行される処理
    }

    public void Exit()
    {
        // Chase 状態から他の状態に遷移するときの終了処理
    }

    private void ChasePlayer(Vector3 playerPosition)
    {
        // プレイヤーの位置に向かって移動する処理をここに追加
        // 例: enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerPosition, enemy.moveSpeed * Time.deltaTime);
    }
}

