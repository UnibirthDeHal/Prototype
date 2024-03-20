using UnityEngine;

public class State_Player_SubAttack : IState
{
    private Control_Player player;
    private Animator animator;
    private Rigidbody rb;

    // �U���̐ݒ�
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;

    public State_Player_SubAttack(Control_Player player)
    {
        this.player = player;
        this.rb = player.GetComponent<Rigidbody>();
    }

    public void Enter()
    {

        Debug.Log("�T�u�A�^�b�N��Ԃɓ�����");
        //player.SetAnimation("Fight");


    }

    public void Execute()
    {
        // �v���C���[�̈ړ�����
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = horizontalInput * player.moveSpeed * Time.deltaTime * Vector3.right;
        player.transform.position += horizontalMove;

        // �v���C���[�������Ă������������
        Vector3 direction = player.transform.right; // �v���C���[�̉E������������

        // ���C�L���X�g�̐ݒ�
        Vector3 rayOrigin = player.transform.position;// + Vector3.up; // �n�ʂƂ̃R���W����������邽�߂ɏ����グ��
        float rayLength = attackRange;
        Debug.DrawRay(rayOrigin, direction * rayLength, Color.red); // �f�o�b�O�p�̃��C���V�[���ɕ`��

        // ���C�L���X�g���s���A�R���W�����ɐڐG�������`�F�b�N
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, direction, out hit, rayLength))
        {
            // �ڐG�����I�u�W�F�N�g���G�̏ꍇ
            if (hit.collider.CompareTag("Enemy"))
            {
                // �_���[�W��^���鏈��
                Debug.Log($"�T�u�U��Hit {hit.collider.name}");

                // �o�b�N���O�ɂ��o��
                Debug.Log("Enemy Hit!");

                // ... �_���[�W���� ...
            }
        }

        player.ChangeState(new Player_State_Idle(player));
    }



    public void Exit()
    {
        // �U�����I��������̃N���[���A�b�v�������K�v�ȏꍇ�͂����ɋL�q
    }
}
