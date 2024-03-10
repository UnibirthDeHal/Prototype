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
        // �W�����v�J�n���̏���
        isGrounded = false; // �n�ʂ��痣��Ă���Ɖ���
        rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.SetAnimation("Jump");
    }

    public void Execute()
    {
        // �W�����v���̏����i�Ⴆ�΁A�󒆑���Ȃǁj
        // �����ł̓V���v���ɂ��Ă��܂����A�K�v�ɉ����Ċg���ł��܂��B

        // �n�ʂɐڐG���������`�F�b�N
        isGrounded = Physics.CheckSphere(player.groundCheck.position, player.groundCheckRadius, player.whatIsGround);
        if (isGrounded)
        {
            player.ChangeState(new Player_State_Idle(player)); // �n�ʂɐڐG������Idle��Ԃɖ߂�
        }
    }

    public void Exit()
    {
        // �W�����v�I�����̏���
    }
}