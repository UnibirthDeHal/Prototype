using UnityEngine;

public class Player_State_Jump : IState
{
    private Control_Player player;
    private Rigidbody rb;

    public Player_State_Jump(Control_Player player)
    {
        this.player = player;
        this.rb = player.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        Debug.Log("ƒWƒƒƒ“ƒvó‘Ô‚É“ü‚Á‚½");
        rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.isGrounded = false;
    }

    public void Execute()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = horizontalInput * player.moveSpeed * Time.deltaTime * Vector3.right;
        player.transform.position += horizontalMove;

        if (rb.velocity.y > 0)
        {
            player.SetAnimation("Jump");
        }
        else if (rb.velocity.y < 0)
        {
            player.ChangeState(new State_Player_Fall(player));
            return;
        }

        // Ground check with additional raycasts to the right and left diagonals
       
        bool isGrounded = CheckGround(player.groundCheck.position, Vector3.down) ||
                          CheckGround(player.groundCheck.position, (Vector3.down + Vector3.right).normalized) ||
                          CheckGround(player.groundCheck.position, (Vector3.down + Vector3.left).normalized);

        if (isGrounded)
        {
            player.isGrounded = true;
            if (Mathf.Abs(horizontalInput) > 0)
            {
                player.ChangeState(new Player_State_Move(player));
            }
            else
            {
                player.ChangeState(new Player_State_Idle(player));
            }
        }
    }

    private bool CheckGround(Vector3 position, Vector3 direction)
    {
        float distance = 0.1f + 0.1f; // Adjust the distance based on your game's needs
        RaycastHit hit;
        if (Physics.Raycast(position, direction, out hit, distance, player.whatIsGround))
        {
            Debug.DrawRay(position, direction * distance, Color.green); // For debugging
            return hit.collider != null;
        }
        return false;
    }

    public void Exit()
    {
        // Jump exit logic if needed
    }
}
