using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlLeg1 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new Leg1_State_Idle(this));
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

}