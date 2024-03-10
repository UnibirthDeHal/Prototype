using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Player_Fall : IState
{
    private ControlPlayer player;
    private Rigidbody rb;

    public State_Player_Fall(ControlPlayer player)
    {
        this.player = player;
        this.rb = player.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        // 落下状態に入る時の処理
        player.SetAnimation("Fall"); // 例えば落下アニメーションの再生
    }

    public void Execute()
    {
        // 落下中の処理
        // ここでは、物理的な落下処理はRigidbodyによって自動的に行われます。
        // 地面に触れたかどうかのチェックは省略しています。
        // 通常は、地面に接触しているかどうかをPhysics.Raycastや
        // Physics.CheckSphereなどを使って確認し、接触していれば状態を変更します。
    }

    public void Exit()
    {
        // 落下状態を抜ける時の処理
    }
}
