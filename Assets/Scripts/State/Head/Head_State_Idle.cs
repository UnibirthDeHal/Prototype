using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Head_State_Idle : IState
{
    private ControlHead Head;

    public Head_State_Idle(ControlHead Head)
    {
        this.Head = Head;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ����瓪�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("�����ҋ@")
        //    Head.SetAnimation("Head(1)Idle");
        Debug.Log("�l���ҋ@");
        Head.SetAnimation("Head(0)Idle");
    }

    public void Execute()
    {
        //Q��E�œ���I�����Ă�����(�I���ł��邾����K�������ɂȂ��Ă���)����Player��SubAttackState�ɓ�������
        //�y��ԑJ�ځzSubAttack��Ԃ�
        //Head.ChangeState(new Head_State_SubAttack(Head));
    }

    public void Exit()
    {

    }
}
