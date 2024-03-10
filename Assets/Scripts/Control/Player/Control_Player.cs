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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの取得
    }

    void Start()
    {
        ChangeState(new Player_State_Idle(this));
    }

    void Update()
    {
        currentState?.Execute();

        // 地面にいるかどうかのチェックは、各ステート内で実施
        // ジャンプ入力を検出
        if (Input.GetButtonDown("Jump"))
        {
            ChangeState(new Player_State_Jump(this));
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Itemとの接触時の処理をここに記述
            Destroy(other.gameObject); // 例: Itemを消去する
        }
    }

   
   //private void Jump()
   //{
   //    // 垂直方向の力を加えてジャンプする
   //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
   //
   //    // ジャンプアニメーションを設定する（アニメーションがある場合）
   //    SetAnimation("Jump");
   //
   //    // ジャンプしたので、地面から離れたと見なす
   //    isGrounded = false;
   //}
   //
   //void OnCollisionEnter(Collision collision)
   //{
   //    // 地面に触れているかを確認する
   //    if (collision.gameObject.CompareTag("Ground"))
   //    {
   //        isGrounded = true;
   //    }
   //}
   //
   //void OnCollisionExit(Collision collision)
   //{
   //    // 地面から離れたことを検出する
   //    if (collision.gameObject.CompareTag("Ground"))
   //    {
   //        isGrounded = false;
   //    }
   //}
}
