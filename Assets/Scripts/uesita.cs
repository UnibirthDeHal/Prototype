using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uesita : MonoBehaviour
{
    public float speed = 2.0f; // �ړ����x
    public float height = 0.5f; // �ړ��̍���

    private Vector3 startPos; // �����ʒu

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �㉺�ɓ�������������
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height, 0);
    }
}

