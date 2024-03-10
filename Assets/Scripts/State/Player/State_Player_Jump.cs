using UnityEngine;

public class Player_State_Jump : IState
{
    private ControlPlayer player;
    private Rigidbody rb;
    private bool isGrounded;

    public Player_State_Jump(ControlPlayer player)
    {
        this.player = player;
        this.rb = player.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        // ジャンプ開始時の処理
        isGrounded = false; // 地面から離れていると仮定
        rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.SetAnimation("Jump");
    }

    public void Execute()
    {
        // ジャンプ中の処理（例えば、空中操作など）
        // ここではシンプルにしていますが、必要に応じて拡張できます。

        // 地面に接触したかをチェック
        isGrounded = Physics.CheckSphere(player.groundCheck.position, player.groundCheckRadius, player.whatIsGround);
        if (isGrounded)
        {
            player.ChangeState(new Player_State_Idle(player)); // 地面に接触したらIdle状態に戻る
        }
    }

    public void Exit()
    {
        // ジャンプ終了時の処理
    }
}