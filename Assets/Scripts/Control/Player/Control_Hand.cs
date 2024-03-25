using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Hand : MonoBehaviour
{
    [Header("[プレイヤー]")]
    public GameObject player;

    [Space]
    public int nowstate;//(0:人 1:竜 2:深海魚)

    [HideInInspector]public SpriteRenderer spriteRenderer;
    [HideInInspector]public Animator animator;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        nowstate = 0;
        ChangeState(new Hand_Human_Idle(this));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Control_Enemy>().Hp -= 2;
        }
    }
}