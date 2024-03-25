using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class Control_Player : MonoBehaviour
{
    //player基礎属性管理
    public float moveSpeed;              //移動速度
    [HideInInspector] public float hp_max;                 //最大HP
    [HideInInspector] public float hp_cur;                 //現在HP

    //各部位
    [Header("[プレイヤーの各部位]")]
    public Control_Head part_head;
    public Control_Hand part_hands;
    public Control_Body part_body;
    public Control_Leg1 part_leg1;
    public Control_Leg2 part_leg2;

    //player各部位状態
    public UI_State_Head ui_head;
    [HideInInspector] public string state_head;

    [Space, Header("[UIに関する]")]
    public HPSlider slider_hp;                             //HPバー
    public GameObject slider_burden;                       //重量バー

    [Space]
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;

    [HideInInspector] public int dir;
    [HideInInspector] private int random;

    //public float move_speed;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;
    [HideInInspector] public bool isjump;
    [HideInInspector] public bool isfall;

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
        //moveSpeed = 5.0f;
        hp_max = 125;
        hp_cur = hp_max;
        dir = 6;
        random = 0;
        isjump = false;
        isfall = false;
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;

        currentState?.Execute();

        CheckGroundedStatus();

        // ジャンプ入力の検出
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isjump = true;
            ChangeState(new Player_State_Jump(this));
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
        if (animator)
        {
            animator.Play(animationName);
        }
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
            for (;;)
            {
                if ((part_head.nowstate == 1) && (part_hands.nowstate == 1) && (part_body.nowstate == 1) && (part_leg1.nowstate == 1) && (part_leg2.nowstate == 1))
                {
                    Debug.Log("全身竜!!");
                    break;
                }

                random = Random.Range(1, 6);

                if (random == 1)
                {
                    if (part_head.nowstate != 1)
                    {
                        part_head.nowstate = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 2)
                {
                    if (part_hands.nowstate != 1)
                    {
                        part_hands.nowstate = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 3)
                {
                    if (part_body.nowstate != 1)
                    {
                        part_body.nowstate = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 4)
                {
                    if (part_leg1.nowstate != 1)
                    {
                        part_leg1.nowstate = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 5)
                {
                    if (part_leg2.nowstate != 1)
                    {
                        part_leg2.nowstate = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //ここに竜遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("魚遺伝子"))
        {
            // Itemとの接触時の処理をここに記述
            for (;;)
            {
                if ((part_head.nowstate == 2) && (part_body.nowstate == 2) && (part_leg2.nowstate == 2))
                {
                    Debug.Log("全身魚!!");
                    break;
                }

                random = Random.Range(1, 4);

                if (random == 1)
                {
                    if (part_head.nowstate != 2)
                    {
                        part_head.nowstate = 2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 2)
                {
                    if (part_body.nowstate != 2)
                    {
                        part_body.nowstate = 2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (random == 3)
                {
                    if (part_leg2.nowstate != 2)
                    {
                        part_leg2.nowstate = 2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //ここに魚遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("ネズミ遺伝子"))
        {
            moveSpeed += 2.0f;
            Debug.Log("ネズミ遺伝子ゲット、Speed Up" + 2.0f);
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

    public void SetSpriteFlip(bool flip)
    {
        if (flip == true)
        {
            if (part_head && part_hands && part_body && part_leg1&&part_leg2)
            {
                part_head.spriteRenderer.flipX = true;
                part_hands.spriteRenderer.flipX = true;
                part_body.spriteRenderer.flipX = true;
                part_leg1.spriteRenderer.flipX = true;
                part_leg2.spriteRenderer.flipX = true;
            }
            else
            {
                Debug.Log("各部位がちゃん設置されていない！");
            }
        }
        else if (flip == false)
        {
            if (part_head && part_hands && part_body && part_leg1 && part_leg2)
            {
                part_head.spriteRenderer.flipX = false;
                part_hands.spriteRenderer.flipX = false;
                part_body.spriteRenderer.flipX = false;
                part_leg1.spriteRenderer.flipX = false;
                part_leg2.spriteRenderer.flipX = false;
            }
            else
            {
                Debug.Log("各部位がちゃん設置されていない！");
            }
        }
    }
}
