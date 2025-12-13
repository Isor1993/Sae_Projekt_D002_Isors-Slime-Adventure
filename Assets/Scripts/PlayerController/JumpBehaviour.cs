
using UnityEngine;

public class JumpBehaviour
{
    // --- Dependencies ---
    private readonly JumpConfig _config;
    private readonly Rigidbody2D _rb;

    // --- Field ---   
    private const int SingleJump= 1;
    private int _jumpCount;  
    
    public int JumpCount=>_jumpCount;
      
    public JumpBehaviour(JumpConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
      
    }

    public bool Jump(bool isGrounded, bool isCoyoteAktive, bool multiJumpEnabled)
    {
        int maxJumpCount = GetMaxJumpCount(multiJumpEnabled);
        if(!CanJumpOnGround(isGrounded) 
            && !CanJumpWithCoyote(isGrounded,isCoyoteAktive)
            && !CanJumpInAir(isGrounded,multiJumpEnabled,maxJumpCount))
        {
            return false; 
        }
           
        PerformJumpPhysic();
        _jumpCount++;
        return true;
    }

    private void PerformJumpPhysic()
    {
        Vector2 currentVelocity = _rb.linearVelocity;
        currentVelocity.y = _config.JumpForce;
        _rb.linearVelocity = currentVelocity;        
    }
    
    private bool CanJumpOnGround(bool isGrounded)
    {
        return isGrounded;
    }
    private bool CanJumpInAir(bool isGrounded, bool multiJumpEnabled,int maxJumpCount)
    {
        return !isGrounded && multiJumpEnabled&&_jumpCount<maxJumpCount;
    }
    private bool CanJumpWithCoyote(bool isGrounded,bool isCoyoteAktive)
    {
        return !isGrounded && isCoyoteAktive;
    }
    private int GetMaxJumpCount(bool multiJumpEnabled)
    {
        return multiJumpEnabled ? _config.MaxJumpCount : SingleJump;
    }
    public void ResetJumpCount()
    {
        _jumpCount = 0;
    }
}



