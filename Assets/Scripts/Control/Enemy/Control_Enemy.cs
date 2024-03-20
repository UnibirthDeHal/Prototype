using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    //public Animator animator;
    public float moveSpeed = 3f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;
    [HideInInspector] public int dir;

    public float move_speed;                                    // ˆÚ“®‘¬“x
    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody for 3D
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new State_Enemy_Idle(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Execute();
    }

    //public void ChangeState(IState newState)
    //{
    //    currentState?.Exit();
    //    currentState = newState;
    //    currentState.Enter();
    //}

    //internal void ChangeState(State_Enemy_Chase state_Enemy_Chase)
    //{
    //    throw new NotImplementedException();
    //}

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}