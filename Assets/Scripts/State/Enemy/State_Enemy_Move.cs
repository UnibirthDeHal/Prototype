using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
//using UnityEngine.Scripting;

//[ExtensionOfNativeClass]
public class State_Enemy_Move : IState
{
    private Control_Enemy enemy;
    private float StartPosX;
    private float LeftPosX;
    private float RightPosX;
    private float dir = -1.0f;
    private int count;
    private int countMax = 2;

    public State_Enemy_Move(Control_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Move ��Ԃɓ������Ƃ��̏������Ȃǂ��s��
        count = 0;
        StartPosX = enemy.transform.position.x;
        LeftPosX = enemy.transform.position.x - (enemy.moverange / 2);
        RightPosX = enemy.transform.position.x + (enemy.moverange / 2);
    }

    public void Execute()
    {
        //�ړ��͈͂ɒH������t�߂�
        if (enemy.transform.position.x <= LeftPosX)
        {
            dir = 1.0f;
            count++;
        }
        else if (enemy.transform.position.x >= RightPosX)
        {
            dir = -1.0f;
            count++;
        }

        //�e�N�X�`���[�̌�����ς��
        if (dir < 0)
        {
            enemy.spriteRenderer.flipX = false;
        }
        else if (dir > 0)
        {
            enemy.spriteRenderer.flipX = true;
        }

        //�ړ�
        enemy.transform.position += new Vector3(dir, 0, 0) * enemy.moveSpeed * Time.deltaTime;

        //���肵����Idle��Ԃɓ���(Bug����)
        //if ((count >= countMax) && ((enemy.transform.position.x >= (StartPosX-0.001f) || (enemy.transform.position.x <= (StartPosX + 0.001f)))))
        //{
        //    enemy.ChangeState(new State_Enemy_Idle(enemy));
        //}

        // Move ��ԂŖ��t���[�����s����鏈��
    }

    public void Exit()
    {
        // Move ��Ԃ��瑼�̏�ԂɑJ�ڂ���Ƃ��̏I������
    }
}

