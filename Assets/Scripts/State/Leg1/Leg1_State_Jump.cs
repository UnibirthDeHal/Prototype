using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Jump : IState
{
    private ControlLeg1 Leg1;

    public Leg1_State_Jump(ControlLeg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ����瑫�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("�����W�����v")
        //    Leg1.SetAnimation("Leg1(1)Jump");
        Debug.Log("�l���W�����v");
        Leg1.SetAnimation("Leg1(1)Jump");
    }

    public void Execute()
    {
        //Player��FallState�ɓ�������
        //�y��ԑJ�ځzFall��Ԃ�
        //Leg1.ChangeState(new Leg1_State_Fall(Leg1));
    }

    public void Exit()
    {

    }
}