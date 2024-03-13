using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_State_SubAttack : IState
{
    private ControlBody Body;

    public Body_State_SubAttack(ControlBody Body)
    {
        this.Body = Body;
    }

    public void Enter()
    {
        Debug.Log("‹›“·UŒ‚");
        Body.SetAnimation("Body(2)SubAttack");
    }

    public void Execute()
    {
        //SubAttackƒAƒjƒ[ƒVƒ‡ƒ“‚ªI‚í‚Á‚½‚ç
        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        //Body.ChangeState(new Body_State_Idle(Body));
    }

    public void Exit()
    {

    }
}
