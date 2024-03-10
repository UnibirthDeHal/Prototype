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
        // ������Ԃɓ��鎞�̏���
        player.SetAnimation("Fall"); // �Ⴆ�Η����A�j���[�V�����̍Đ�
    }

    public void Execute()
    {
        // �������̏���
        // �����ł́A�����I�ȗ���������Rigidbody�ɂ���Ď����I�ɍs���܂��B
        // �n�ʂɐG�ꂽ���ǂ����̃`�F�b�N�͏ȗ����Ă��܂��B
        // �ʏ�́A�n�ʂɐڐG���Ă��邩�ǂ�����Physics.Raycast��
        // Physics.CheckSphere�Ȃǂ��g���Ċm�F���A�ڐG���Ă���Ώ�Ԃ�ύX���܂��B
    }

    public void Exit()
    {
        // ������Ԃ𔲂��鎞�̏���
    }
}
