using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
//using UnityEngine.Scripting;

//[ExtensionOfNativeClass]
public class State_Enemy_Chase : IState
{
    private Control_Enemy enemy;
    private Transform playerTransform;  // �v���C���[�� Transform �R���|�[�l���g

    public State_Enemy_Chase(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Chase ��Ԃɓ������Ƃ��̏������Ȃǂ��s��
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Execute()
    {
        // �v���C���[�̈ʒu���擾
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // �v���C���[��Ǐ]���鏈��
        ChasePlayer(playerPosition);

        // Chase ��ԂŖ��t���[�����s����鏈��
    }

    public void Exit()
    {
        // Chase ��Ԃ��瑼�̏�ԂɑJ�ڂ���Ƃ��̏I������
    }

    private void ChasePlayer(Vector3 playerPosition)
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ����鏈���������ɒǉ�
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerPosition, enemy.moveSpeed * Time.deltaTime);
    }
}

