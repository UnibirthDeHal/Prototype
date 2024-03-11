using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Player_Fall : IState
{
    private ControlPlayer player;

    public State_Player_Fall(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("落下状態に入った");
        // 落下状態に入る時の処理
        player.SetAnimation("Fall"); // 例えば落下アニメーションの再生
    }

    public void Execute()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = horizontalInput * player.moveSpeed * Time.deltaTime * Vector3.right;
        player.transform.position += horizontalMove;
        // 地面との衝突判定
        RaycastHit hit;
        // レイキャストをplayerの位置から下方向に放出し、地面との接触を確認
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, 1f, player.whatIsGround))
        {
            // 地面に接触した場合、Idle状態へ遷移
            if (hit.collider != null)
            {
                player.ChangeState(new Player_State_Idle(player));
            }
        }
    }

    public void Exit()
    {
        // 落下状態を抜ける時の処理
    }
}
