using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leg2_State_SubAttack : IState
{
    private ControlLeg2 Leg2;

    public Leg2_State_SubAttack(ControlLeg2 Leg2)
    {
        this.Leg2 = Leg2;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ�����K���̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("���K���U��")
        //    Head.SetAnimation("Leg2(1)SubAttack");
        Debug.Log("���K���U��");
        Leg2.SetAnimation("Leg2(2)SubAttack");
    }

    public void Execute()
    {
        //SubAttack�A�j���[�V�������I�������
        //�y��ԑJ�ځzIdle��Ԃ�
        //Leg2.ChangeState(new Leg2_State_Idle(Leg2));
    }

    public void Exit()
    {

    }
}