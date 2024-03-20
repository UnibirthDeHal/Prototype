using UnityEngine;

public class State_Player_SubAttack : IState
{
    private Control_Player player;
    private Animator animator;
    private Rigidbody rb;

    // 攻撃の設定
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

        Debug.Log("サブアタック状態に入った");
        //player.SetAnimation("Fight");


    }

    public void Execute()
    {
        // プレイヤーの移動処理
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = horizontalInput * player.moveSpeed * Time.deltaTime * Vector3.right;
        player.transform.position += horizontalMove;

        // プレイヤーが向いている方向を決定
        Vector3 direction = player.transform.right; // プレイヤーの右側方向を向く

        // レイキャストの設定
        Vector3 rayOrigin = player.transform.position;// + Vector3.up; // 地面とのコリジョンを避けるために少し上げる
        float rayLength = attackRange;
        Debug.DrawRay(rayOrigin, direction * rayLength, Color.red); // デバッグ用のレイをシーンに描画

        // レイキャストを行い、コリジョンに接触したかチェック
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, direction, out hit, rayLength))
        {
            // 接触したオブジェクトが敵の場合
            if (hit.collider.CompareTag("Enemy"))
            {
                // ダメージを与える処理
                Debug.Log($"サブ攻撃Hit {hit.collider.name}");

                // バックログにも出力
                Debug.Log("Enemy Hit!");

                // ... ダメージ処理 ...
            }
        }

        player.ChangeState(new Player_State_Idle(player));
    }



    public void Exit()
    {
        // 攻撃が終了した後のクリーンアップ処理が必要な場合はここに記述
    }
}
