using UnityEngine;

public class Player_State_Jump : IState
{
    private ControlPlayer player;
    private Rigidbody rb;
    internal bool isGrounded;
    public Player_State_Jump(ControlPlayer player)
    {
        this.player = player;
        this.rb = player.GetComponent<Rigidbody>();
    }


    public void Enter()
    {
        // ジャンプ開始時の処理
        player.SetAnimation("Jump");
        rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.isGrounded = false; // 地面から離れていると仮定
        player.timer_noInput = 0;
    }

    public void Execute()
    {
        // ジャンプ中の空中操作などの処理をここに追加できます。

        // 地面に接触したかをチェック
        RaycastHit hit;
        if (Physics.Raycast(player.groundCheck.position, Vector3.down, out hit, player.groundCheckRadius, player.whatIsGround))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                // 水平軸の入力に応じて状態を変更
                float horizontalInput = Input.GetAxis("Horizontal");
                if (Mathf.Abs(horizontalInput) > 0)
                {
                    player.ChangeState(new Player_State_Move(player));
                }
                else
                {
                    player.ChangeState(new Player_State_Idle(player));
                }
            }
        }
    }


    public void Exit()
    {
        // ジャンプ終了時の処理をここに追加します。
        // 例えば、ジャンプに関連した変数のリセットなど。
    }
}