using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Player : MonoBehaviour
{
    //player基礎属性管理
    [HideInInspector] public float moveSpeed;              //移動速度
    [HideInInspector] public float hp_max;                 //最大HP
    [HideInInspector] public float hp_cur;                 //現在HP

    //player各部位状態
    public UI_State_Head ui_head;
    [HideInInspector] public string state_head;

    [Space, Header("[UIに関する]")]
    public HPSlider slider_hp;                             //HPバー
    public GameObject slider_burden;                       //重量バー

    [Space]
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;

    [HideInInspector] public int dir;

    //public float move_speed;
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

        //初期化
        moveSpeed = 5.0f;
        hp_max = 125;
        hp_cur = hp_max;
    }

    void Update()
    {

        currentState?.Execute();

        CheckGroundedStatus();

        // ジャンプ入力の検出
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            ChangeState(new Player_State_Jump(this));
        }

        // 攻撃入力の検出（左クリック）
        //メインアタック
        if (Input.GetKey(KeyCode.F))
        {
            ChangeState(new State_Player_Attack(this));
        }
        //サブアタック
        if (Input.GetKey(KeyCode.R))
        {
            ChangeState(new State_Player_SubAttack(this));
        }
    }

    void CheckGroundedStatus()
    {
        Vector3 rayStart = groundCheck.position;
        Vector3 rayDirection = Vector3.down;
        float rayLength = 1f; // 適宜調整
        RaycastHit hit;

        isGrounded = Physics.Raycast(rayStart, rayDirection, out hit, rayLength, whatIsGround);

        // デバッグ用にレイをシーンに表示
        Debug.DrawRay(rayStart, rayDirection * rayLength, isGrounded ? Color.green : Color.red);
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
        if (other.CompareTag("竜遺伝子"))
        {
            // Itemとの接触時の処理をここに記述
            if (ui_head)
            {
                ui_head.ChangePart("Dragon");
            }

            //ここに竜遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("魚遺伝子"))
        {
            // Itemとの接触時の処理をここに記述
            if (ui_head)
            {
                ui_head.ChangePart("Fish");
            }
            //ここに魚遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("ネズミ遺伝子"))
        {
            moveSpeed += 1.0f;
            Debug.Log("ネズミ遺伝子ゲット、Speed Up" + 1.0f);
            // Itemとの接触時の処理をここに記述

            //ここにネズミ遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("亀遺伝子"))
        {
            hp_max += 25f;
            if (slider_hp != null)
            {
                Debug.Log("更新");
                slider_hp.RefreshHealth();
            }
            Debug.Log("亀遺伝子ゲット、Hp Max Up" + 25.0f);
            // Itemとの接触時の処理をここに記述

            //ここに亀遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
    }
}
