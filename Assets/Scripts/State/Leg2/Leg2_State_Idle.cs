using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg2_State_Idle : IState
{
    private Control_Leg2 Leg2;

    public Leg2_State_Idle(Control_Leg2 Leg2)
    {
        this.Leg2 = Leg2;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ�����K���̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("���K���ҋ@")
        //    Leg2.SetAnimation("Leg2(1)Idle");
        Debug.Log("�l�K���Ȃ�");
        Leg2.SetAnimation("Leg2(0)Idle");
    }

    public void Execute()
    {
        //Q��E�ŐK����I�����Ă�����(�I���ł��邾����K���K����������)����Player��SubAttackState�ɓ�������
        //�y��ԑJ�ځzSubAttack��Ԃ�
        //Leg2.ChangeState(new Leg2_State_SubAttack(Leg2));
    }

    public void Exit()
    {

    }
}
