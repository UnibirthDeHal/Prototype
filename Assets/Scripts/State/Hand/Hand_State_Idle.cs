using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand_State_Idle : IState
{
    private Control_Hand Hand;

    public Hand_State_Idle(Control_Hand Hand)
    {
        this.Hand = Hand;
    }

    public void Enter()
    {
        //�ψُ󋵊Ǘ�����r�̕ψُ󋵂��擾
        //Switch�ŕψُ󋵂ɂ���ăA�j���[�V�������Z�b�g
        //��FDebug.Log("���r�ҋ@")
        //    Head.SetAnimation("Hand(1)Idle");
        Debug.Log("�l�r�ҋ@");
        Hand.SetAnimation("Hand(0)Idle");
    }

    public void Execute()
    {
        //Player��AttackState�ɓ�������
        //�y��ԑJ�ځzAttack��Ԃ�
        //Hand.ChangeState(new Hand_State_SubAttack(Hand));
    }

    public void Exit()
    {

    }
}
