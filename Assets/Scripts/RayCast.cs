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
        // �v���C���[�̈ړ����󂯎��
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �v���C���[�̈ړ��ʂ��v�Z����
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;

        // �v���C���[�̌��݈ʒu����ǂ܂ł̋������m�F����
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude);

        // �ǂ����蔲���Ȃ�
        if (hit.collider != null && hit.distance < minDistanceToWall)
        {
            movement = Vector2.zero;
        }

        // �v���C���[���ړ�������
        rb.MovePosition(rb.position + movement);
    }
}