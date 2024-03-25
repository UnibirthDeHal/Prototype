using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Leg2 : MonoBehaviour
{
    [Header("[プレイヤー]")]
    public Control_Player player;

    [Space]
    public int nowstate;//(0:人 1:竜 2:深海魚)

    [HideInInspector]public SpriteRenderer spriteRenderer;
    [HideInInspector]public Animator animator;
    [HideInInspector]public bool isAttacked;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        nowstate = 0;
        isAttacked=false;
        ChangeState(new Leg2_Human_Idle(this));
    }

    void Update()
    {
        // 現在のステート
        currentState?.Execute();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public bool AnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Control_Enemy>().Hp -= 3;
            this.GetComponent<BoxCollider>().enabled = false;
            isAttacked = true;
        }
    }
}