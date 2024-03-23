using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Body_State_Idle : IState
{
    private Control_Body Body;

    public Body_State_Idle(Control_Body Body)
    {
        this.Body = Body;
    }

    public void Enter()
    {
        //変異状況管理から胴体の変異状況を取得
        //Switchで変異状況によってアニメーションをセット
        //例：Debug.Log("竜胴待機")
        //    Head.SetAnimation("Body(1)Idle");
        Debug.Log("人胴待機");
        Body.SetAnimation("Body(0)Idle");
    }

    public void Execute()
    {
        //QとEで胴体を選択している状態(選択できるだから必ず魚胴体になっている)かつPlayerがSubAttackStateに入ったら
        //【状態遷移】SubAttack状態に
        //Body.ChangeState(new Body_State_SubAttack(Body));
    }

    public void Exit()
    {

    }
}
