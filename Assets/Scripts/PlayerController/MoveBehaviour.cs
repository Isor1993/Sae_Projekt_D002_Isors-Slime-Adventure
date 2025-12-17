/*****************************************************************************
* Project : Monsterkampf-Simulator (K1, S1, S4)
* File    : 
* Date    : xx.xx.2025
* Author  : Eric Rosenberg
*
* Description :
* *
* History :
* xx.xx.2025 ER Created
******************************************************************************/
using UnityEngine;



public class MoveBehaviour
{
    //--- Dependencies ---
    private readonly MoveConfig _config;
    private readonly Rigidbody2D _rb;

    //--- Fields ---
    private bool _isGrounded = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="rb"></param>
    public MoveBehaviour(MoveConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputX"></param>
    /// <param name="isSprinting"></param>
    public void Move(float inputX, bool isSprinting)
    {
        Vector2 velocity;
        if (_isGrounded)
        {
            velocity = OnGround(inputX, isSprinting);
        }
        else
        {
            velocity = InAir(inputX,isSprinting);
        }
        _rb.linearVelocity = velocity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputX"></param>
    /// <param name="isSprinting"></param>
    /// <returns></returns>
    public Vector2 OnGround(float inputX, bool isSprinting)
    {
        float moveSpeed = inputX * _config.MoveSpeed;
        float sprintSpeed = inputX * _config.SprintSpeed;
        float targetSpeed = isSprinting ? sprintSpeed : moveSpeed;  
        float MaxSpeed= isSprinting? _config.MaxSprintSpeed:_config.MaxSpeed;
        var currentVelocity = _rb.linearVelocity;
        if (inputX != 0)
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, targetSpeed, _config.Acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0, _config.Deceleration * Time.fixedDeltaTime);
        }
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -MaxSpeed, MaxSpeed);
        return currentVelocity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="InputX"></param>
    /// <param name="isSprinting"></param>
    /// <returns></returns>
    private Vector2 InAir(float InputX, bool isSprinting)
    {

        float airMaxSpeed = (isSprinting?_config.MaxSprintSpeed: _config.MaxSpeed) * _config.AirControlFactor;
        float targetspeed = InputX * airMaxSpeed;
        var currentVelocity = _rb.linearVelocity;
        if (InputX != 0)
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, targetspeed, _config.AirAcceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0, _config.AirDeceleration * Time.fixedDeltaTime);
        }
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -airMaxSpeed, airMaxSpeed);
        return currentVelocity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isGrounded"></param>
    public void SetGroundedState(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}
