using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State_Enemy_Idle : IState
{
    private Control_Enemy enemy;

    public State_Enemy_Idle(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Idle ��Ԃɓ������Ƃ��̏������Ȃǂ��s��
    }

    public void Execute()
    {
        // Idle ��ԂŖ��t���[�����s����鏈��
    }

    public void Exit()
    {
        // Idle ��Ԃ��瑼�̏�ԂɑJ�ڂ���Ƃ��̏I������
    }
}
