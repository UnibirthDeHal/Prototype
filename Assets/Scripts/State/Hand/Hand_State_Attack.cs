using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_State_Attack : IState
{
    private ControlHand Hand;

    public Hand_State_Attack(ControlHand Hand)
    {
        this.Hand = Hand;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ�����r�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("���r�U��")
        //    Head.SetAnimation("Hand(1)Attack");
        Debug.Log("�l�r�U��");
        Hand.SetAnimation("Hand(0)Attack");
    }

    public void Execute()
    {
        //Attack�A�j���[�V�������I�������
        //�y��ԑJ�ځzIdle��Ԃ�
        //Hand.ChangeState(new Hand_State_Idle(Hand));
    }

    public void Exit()
    {

    }
}
