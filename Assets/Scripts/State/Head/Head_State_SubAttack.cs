using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Head_State_SubAttack : IState
{
    private Control_Head Head;

    public Head_State_SubAttack(Control_Head Head)
    {
        this.Head = Head;
    }

    public void Enter()
    {
        Debug.Log("�����U��");
        Head.SetAnimation("Head(1)Attack");
    }

    public void Execute()
    {
        //SubAttack�A�j���[�V�������I�������
        //�y��ԑJ�ځzIdle��Ԃ�
        //Head.ChangeState(new Head_State_Idle(Head));
    }

    public void Exit()
    {

    }
}
