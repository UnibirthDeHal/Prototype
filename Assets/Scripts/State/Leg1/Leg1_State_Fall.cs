using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Fall : IState
{
    private Control_Leg1 Leg1;

    public Leg1_State_Fall(Control_Leg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ����瑫�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("��������")
        //    Leg1.SetAnimation("Leg1(1)Fall");
        Debug.Log("�l������");
        Leg1.SetAnimation("Leg1(1)Fall");
    }

    public void Execute()
    {
        //Player��IdleState�ɓ�������
        //�y��ԑJ�ځzIdle��Ԃ�
        //Leg1.ChangeState(new Leg1_State_idle(Leg1));
    }

    public void Exit()
    {

    }
}
