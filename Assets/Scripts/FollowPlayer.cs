using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] public Transform Player;
    Vector3 distance;
    [SerializeField] public float SmoothTime = 0.3f;
    Vector3 Velocity = Vector3.zero;

    void Start()
    {
        // プレイヤーとカメラの初期距離を保持
        distance = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        // 目標位置をプレイヤーの位置に基づいて計算（水平方向は即時反映、垂直方向は遅延を持たせる）
        Vector3 targetPosition = Player.transform.position + distance;

        // 水平方向のみをSmoothDampで滑らかに追従
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, transform.position.y, targetPosition.z), ref Velocity, SmoothTime);

        // 垂直方向の追従に遅延を持たせる
        smoothPosition.y = Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * SmoothTime * 10);

        // カメラの位置を更新
        transform.position = smoothPosition;
    }
}
