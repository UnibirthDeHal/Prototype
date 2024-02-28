using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;


public class ControlPlayer : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    //public float health = 10;                                 
    //[HideInInspector] public float cd_hurt;                     

    [HideInInspector] public int dir;                           // 向き（2上 4左 8下 6右）

    //（!）Stateに関する変数はStateのScriptで管理しないように
    //【State】移動（Move）
    public float move_speed;                                    // 移動速度
    [HideInInspector] public float timer_noInput;           // （timer）入力していない時間
    [HideInInspector] public float threshold_noInput;    // 入力していない時間の閾値(しきいち)

    //状态机（StateMachine）
    private IState state_current;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
    void OnDestroy()
    {

    }

    // Start is called before the first frame update
    void Start()        // 初期化
    {
        ChangeState(new Player_State_Idle(this));

        dir = 6;                    // 登場時の向き（右）
        //cd_hurt = 2f;           

        //【State】移动（Move）
        timer_noInput = 0;
        threshold_noInput = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        // 現在のステート
        state_current?.Execute();

    }




    public void ChangeState(IState newState)
    {
        state_current?.Exit();
        state_current = newState;
        state_current.Enter();
    }
    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    //「アニメションが終わったか？」をチェック
    public bool AnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

}
