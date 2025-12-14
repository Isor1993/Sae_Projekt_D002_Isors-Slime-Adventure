
using UnityEngine;

public class JumpBehaviour
{
    // --- Dependencies ---
    private readonly JumpConfig _config;
    private readonly Rigidbody2D _rb;

    // --- Field ---     

    private int _jumpCountAir; private bool _groundJumpAvailable = true;




    public JumpBehaviour(JumpConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;

    }

    public bool Jump(bool isGrounded, bool isCoyoteAktive, bool multiJumpEnabled, bool isTouchingWall, bool wallJumpEnabled)
    {
        if (CanJumpOnGround(isGrounded, isCoyoteAktive))
        {
            PerformJumpPhysic();
            _groundJumpAvailable = false;
            Debug.Log("Player jumped from Ground.");
            return true;
        }
        if (CanWallJump(isTouchingWall,isGrounded, wallJumpEnabled))
        {
            PerformJumpPhysic();
            _jumpCountAir++;
            Debug.Log("Player jumped from wall.");
            return true;

        }
        if (CanJumpInAir(isGrounded, multiJumpEnabled))
        {
            PerformJumpPhysic();
            _jumpCountAir++;
            Debug.Log("Player jumped in air.");
            return true;
        }
        return false;
    }

    private void PerformJumpPhysic()
    {
        Vector2 currentVelocity = _rb.linearVelocity;
        currentVelocity.y = _config.JumpForce;
        _rb.linearVelocity = currentVelocity;
    }

    private bool CanJumpOnGround(bool isGrounded, bool isCoyoteAktive)
    {
        return _groundJumpAvailable && (isGrounded || isCoyoteAktive);
    }
    private bool CanJumpInAir(bool isGrounded, bool multiJumpEnabled)
    {
        return !isGrounded && _jumpCountAir < _config.MaxJumpCountAir && multiJumpEnabled;
    }
    private bool CanWallJump(bool isTouchingWall, bool isGrounded, bool wallJumpEnabled)
    {
        return !isGrounded&&isTouchingWall&&_jumpCountAir < _config.MaxJumpCountAir && wallJumpEnabled;
    }

    public void ResetJumpCountAir()
    {
        _jumpCountAir = 0;
    }
    public void ResetJumpCountGround()
    {
        _groundJumpAvailable = true;
    }
}



