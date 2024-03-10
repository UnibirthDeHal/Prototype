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
        // �W�����v�J�n���̏���
        player.SetAnimation("Jump");
        rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.isGrounded = false; // �n�ʂ��痣��Ă���Ɖ���
        player.timer_noInput = 0;
    }

    public void Execute()
    {
        // �W�����v���̋󒆑���Ȃǂ̏����������ɒǉ��ł��܂��B

        // �n�ʂɐڐG���������`�F�b�N
        RaycastHit hit;
        if (Physics.Raycast(player.groundCheck.position, Vector3.down, out hit, player.groundCheckRadius, player.whatIsGround))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                // �������̓��͂ɉ����ď�Ԃ�ύX
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
        // �W�����v�I�����̏����������ɒǉ����܂��B
        // �Ⴆ�΁A�W�����v�Ɋ֘A�����ϐ��̃��Z�b�g�ȂǁB
    }
}