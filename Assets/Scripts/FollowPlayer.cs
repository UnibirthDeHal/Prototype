using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformをアサイン
    public Vector3 offset; // カメラとプレイヤーの間のオフセット

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの位置にオフセットを加えた位置にカメラを移動させる
        transform.position = player.position + offset;
    }
}
