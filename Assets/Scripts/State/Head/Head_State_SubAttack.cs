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
        Debug.Log("—³“ªUŒ‚");
        Head.SetAnimation("Head(1)Attack");
    }

    public void Execute()
    {
        //SubAttackƒAƒjƒ[ƒVƒ‡ƒ“‚ªI‚í‚Á‚½‚ç
        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        //Head.ChangeState(new Head_State_Idle(Head));
    }

    public void Exit()
    {

    }
}
