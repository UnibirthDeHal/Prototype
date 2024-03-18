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
        enemy.idletimer = 0;
    }

    public void Execute()
    {
        enemy.idletimer += Time.deltaTime;

        // ���͎��Ԍ�Move��Ԃɓ���
        if (enemy.idletimer > enemy.endidletime)
        {
            enemy.ChangeState(new State_Enemy_Move(enemy));
        }

        // Idle ��ԂŖ��t���[�����s����鏈��
    }

    public void Exit()
    {
        // Idle ��Ԃ��瑼�̏�ԂɑJ�ڂ���Ƃ��̏I������
    }
}
