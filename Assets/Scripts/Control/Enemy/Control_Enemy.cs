using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Control_Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float moveSpeed;
    private Rigidbody rb;
    private IState currentState;

    [HideInInspector] public float idletimer;
    public float endidletime;

    public int Hp = 2;
    [Header("ドロップ遺伝子")][SerializeField] GameObject DorpItem;
    [Header("移動範囲")]public float moverange;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        isDead();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    void isDead()
    {
        if (Hp <= 0)
        {
            Instantiate(DorpItem,this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}