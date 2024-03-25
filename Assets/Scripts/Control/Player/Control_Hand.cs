using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Hand : MonoBehaviour
{
    [Header("[�v���C���[]")]
    public GameObject player;

    [Space]
    public int nowstate;//(0:�l 1:�� 2:�[�C��)

    [HideInInspector]public SpriteRenderer spriteRenderer;
    [HideInInspector]public Animator animator;
    [HideInInspector] public bool isAttacked;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        nowstate = 0;
        isAttacked= false;
        ChangeState(new Hand_Human_Idle(this));
    }

    void Update()
    {
        // ���݂̃X�e�[�g
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
            this.GetComponent<BoxCollider>().enabled = false;
            isAttacked = true;
        }
    }
}