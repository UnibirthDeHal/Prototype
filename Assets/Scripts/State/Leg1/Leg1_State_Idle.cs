using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg1_State_Idle : IState
{
    private ControlLeg1 Leg1;

    public Leg1_State_Idle(ControlLeg1 Leg1)
    {
        this.Leg1 = Leg1;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ����瑫�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("�����ҋ@")
        //    Leg1.SetAnimation("Leg1(1)Idle");
        Debug.Log("�l���ҋ@");
        Leg1.SetAnimation("Leg1(1)Idle");
    }

    public void Execute()
    {
        //Player��MoveState/JumpState�ɓ�������
        //�y��ԑJ�ځzMove��Ԃ�
        //Leg1.ChangeState(new Leg1_State_Move(Leg1));
        //�y��ԑJ�ځzJump��Ԃ�
        //Leg1.ChangeState(new Leg1_State_Jump(Leg1));
    }

    public void Exit()
    {

    }
}
