using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State_Enemy_Idle : MonoBehaviour
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
        // �v���C���[�̈ʒu���擾
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPosition = playerTransform.position;

        // �G�l�~�[�ƃv���C���[�̋������v�Z
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerPosition);

        // ���͈͈ȉ��ɂȂ����ꍇ�AChase ��ԂɑJ��
        if (distanceToPlayer < 5f) // 5f�͓K�؂Ȕ͈̗͂�ł�
        {
            enemy.ChangeState(new State_Enemy_Chase(enemy));
        }

        // Idle ��ԂŖ��t���[�����s����鏈��
    }

    public void Exit()
    {
        // Idle ��Ԃ��瑼�̏�ԂɑJ�ڂ���Ƃ��̏I������
    }
}
