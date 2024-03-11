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
        Debug.Log("������Ԃɓ�����");
        // ������Ԃɓ��鎞�̏���
        player.SetAnimation("Fall"); // �Ⴆ�Η����A�j���[�V�����̍Đ�
    }

    public void Execute()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = horizontalInput * player.moveSpeed * Time.deltaTime * Vector3.right;
        player.transform.position += horizontalMove;
        // �n�ʂƂ̏Փ˔���
        RaycastHit hit;
        // ���C�L���X�g��player�̈ʒu���牺�����ɕ��o���A�n�ʂƂ̐ڐG���m�F
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, 1f, player.whatIsGround))
        {
            // �n�ʂɐڐG�����ꍇ�AIdle��Ԃ֑J��
            if (hit.collider != null)
            {
                player.ChangeState(new Player_State_Idle(player));
            }
        }
    }

    public void Exit()
    {
        // ������Ԃ𔲂��鎞�̏���
    }
}
