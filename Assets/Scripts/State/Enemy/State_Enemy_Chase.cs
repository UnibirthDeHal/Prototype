using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
//using UnityEngine.Scripting;

//[ExtensionOfNativeClass]
public class State_Enemy_Chase : IState
{
    private Control_Enemy enemy;
    private Transform playerTransform;  // プレイヤーの Transform コンポーネント

    public State_Enemy_Chase(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Chase 状態に入ったときの初期化などを行う
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Execute()
    {
        // プレイヤーの位置を取得
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

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
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerPosition, enemy.moveSpeed * Time.deltaTime);
    }
}

