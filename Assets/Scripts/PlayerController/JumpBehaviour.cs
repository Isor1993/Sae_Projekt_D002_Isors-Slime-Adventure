
using UnityEngine;

public class JumpBehaviour
{
    private readonly JumpConfig _config;
    private readonly Rigidbody2D _rb;
    public int _jumpCount = 0;

    public JumpBehaviour(JumpConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
    }


    public bool Jump(bool isGrounded, bool isCoyote)
    {
        bool canJumpGround = (isGrounded || isCoyote) && _jumpCount < _config.MaxJumpCount;
        bool canJumpAir = (!isGrounded && !isCoyote) && _jumpCount < _config.MaxJumpCount;

        if (!canJumpGround && !canJumpAir)
        {
            return false;
        }

        Vector2 currentVelocity = _rb.linearVelocity;
        currentVelocity.y = _config.JumpForce;
        _rb.linearVelocity = currentVelocity;
        _jumpCount++;

        return true;
    }
}
