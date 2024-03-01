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
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;
    [HideInInspector] public int dir;                           // 向き（2上 4左 8下 6右）

    //（!）Stateに関する変数はStateのScriptで管理しないように
    //【State】移動（Move）
    public float move_speed;                                    // 移動速度
    [HideInInspector] public float timer_noInput;           // （timer）入力していない時間
    [HideInInspector] public float threshold_noInput;    // 入力していない時間の閾値(しきいち)
    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody for 3D
    }

    void Start()
    {
        ChangeState(new Player_State_Idle(this));
    }

    void Update()
    {
        currentState?.Execute();

        // Ground check for 3D
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);

        // 地面にいるときのみジャンプを許可する
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Itemとの接触時の処理をここに記述
            Destroy(other.gameObject); // 例: Itemを消去する
        }
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

    private void Jump()
    {
        // 垂直方向の力を加えてジャンプする
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // ジャンプアニメーションを設定する（アニメーションがある場合）
        SetAnimation("Jump");

        // ジャンプしたので、地面から離れたと見なす
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 地面に触れているかを確認する
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 地面から離れたことを検出する
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
