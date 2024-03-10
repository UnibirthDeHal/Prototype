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
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;

    [HideInInspector] public int dir;

    public float move_speed;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;

    // Rigidbodyの定義を修正
    private Rigidbody rb;
    private IState currentState;
    private Transform _transform;
    // このフラグはプレイヤーが地面にいるかどうかを追跡します
    internal bool isGrounded;
   

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの取得
    }

    void Start()
    {
        _transform = transform;
        ChangeState(new Player_State_Idle(this));
    }


    void Update()
    {
        currentState?.Execute();

        // レイキャストのスタート地点をプレイヤーのタグから決定します。
        // ここでは groundCheck 位置を使用していますが、これはプレイヤーにアタッチされているべきです。
        Vector3 rayStart = groundCheck.position;
        Vector3 rayDirection = Vector3.down;
        float rayLength = 1f; // レイキャストの長さ、プレイヤーが浮いているかどうかを判断するのに十分な長さに設定する
        RaycastHit hit;

        // レイキャストを放出し、ヒットしたものが "Ground" レイヤーに属しているかを確認する
        if (Physics.Raycast(rayStart, rayDirection, out hit, rayLength, whatIsGround))
        {
            isGrounded = hit.collider != null;
        }
        else
        {
            isGrounded = false;
        }

        // 接地状態のデバッグログ
        Debug.Log($"Grounded: {isGrounded}");

        // デバッグ用にレイをシーンに表示
        Debug.DrawRay(rayStart, rayDirection * rayLength, isGrounded ? Color.green : Color.red);

        // ジャンプ入力の検出
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ChangeState(new Player_State_Jump(this));
        }
        // 移動入力の検出（水平軸が0でない場合）
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            ChangeState(new Player_State_Move(this));
        }
        // 何も入力がない場合
        else if (Input.GetAxisRaw("Horizontal") == 0 && isGrounded)
        {
            ChangeState(new Player_State_Idle(this));
        }
    }

    // 状態を変更するメソッド
    public void ChangeState(IState newState)
    {
        currentState?.Exit(); // 現在の状態の Exit を呼び出し
        currentState = newState;
        currentState.Enter(); // 新しい状態の Enter を呼び出し
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Itemとの接触時の処理をここに記述
            Destroy(other.gameObject); // 例: Itemを消去する
        }
    }

   
  
}
