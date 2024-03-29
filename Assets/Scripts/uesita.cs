using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uesita : MonoBehaviour
{
    public float speed = 2.0f; // 移動速度
    public float height = 0.5f; // 移動の高さ

    private Vector3 startPos; // 初期位置

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 上下に動く動きをつける
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height, 0);
    }
}

