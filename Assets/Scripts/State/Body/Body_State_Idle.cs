using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_State_Idle : IState
{
    private Control_Body Body;

    public Body_State_Idle(Control_Body Body)
    {
        this.Body = Body;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ����瓷�̂̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("�����ҋ@")
        //    Head.SetAnimation("Body(1)Idle");
        Debug.Log("�l���ҋ@");
        Body.SetAnimation("Body(0)Idle");
    }

    public void Execute()
    {
        //Q��E�œ��̂�I�����Ă�����(�I���ł��邾����K�������̂ɂȂ��Ă���)����Player��SubAttackState�ɓ�������
        //�y��ԑJ�ځzSubAttack��Ԃ�
        //Body.ChangeState(new Body_State_SubAttack(Body));
    }

    public void Exit()
    {

    }
}
