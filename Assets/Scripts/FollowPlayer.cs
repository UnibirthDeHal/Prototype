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
        // �v���C���[�ƃJ�����̏���������ێ�
        distance = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        // �ڕW�ʒu���v���C���[�̈ʒu�Ɋ�Â��Čv�Z�i���������͑������f�A���������͒x������������j
        Vector3 targetPosition = Player.transform.position + distance;

        // ���������݂̂�SmoothDamp�Ŋ��炩�ɒǏ]
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, transform.position.y, targetPosition.z), ref Velocity, SmoothTime);

        // ���������̒Ǐ]�ɒx������������
        smoothPosition.y = Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * SmoothTime * 10);

        // �J�����̈ʒu���X�V
        transform.position = smoothPosition;
    }
}
