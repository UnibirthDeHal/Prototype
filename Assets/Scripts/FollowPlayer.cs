using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���A�T�C��
    public Vector3 offset; // �J�����ƃv���C���[�̊Ԃ̃I�t�Z�b�g

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̈ʒu�ɃI�t�Z�b�g���������ʒu�ɃJ�������ړ�������
        transform.position = player.position + offset;
    }
}
