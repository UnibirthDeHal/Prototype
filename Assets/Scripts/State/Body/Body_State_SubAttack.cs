using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_State_SubAttack : IState
{
    private Control_Body Body;

    public Body_State_SubAttack(Control_Body Body)
    {
        this.Body = Body;
    }

    public void Enter()
    {
        Debug.Log("·U");
        Body.SetAnimation("Body(2)SubAttack");
    }

    public void Execute()
    {
        //SubAttackAj[VͺIνΑ½η
        //yσΤJΪzIdleσΤΙ
        //Body.ChangeState(new Body_State_Idle(Body));
    }

    public void Exit()
    {

    }
}
