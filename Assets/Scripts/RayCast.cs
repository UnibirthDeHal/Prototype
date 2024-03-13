using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float minDistanceToWall = 0.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // プレイヤーの移動を受け取る
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // プレイヤーの移動量を計算する
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;

        // プレイヤーの現在位置から壁までの距離を確認する
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude);

        // 壁をすり抜けない
        if (hit.collider != null && hit.distance < minDistanceToWall)
        {
            movement = Vector2.zero;
        }

        // プレイヤーを移動させる
        rb.MovePosition(rb.position + movement);
    }
}