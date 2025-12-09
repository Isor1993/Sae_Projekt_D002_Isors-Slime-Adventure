using UnityEngine;


public class MoveBehaviour
{

    private readonly MoveConfig _config;
    private readonly Rigidbody2D _rb;

    public MoveBehaviour(MoveConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
    }

    //TODO velocitySmoothing and airBehaviour
    public void Move(float inputX)
    {
        float targetSpeed = inputX * _config.MaxSpeed;
        var currentVelocity = _rb.linearVelocity;
        if (inputX != 0)
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, targetSpeed, _config.Acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0, _config.Deceleration * Time.fixedDeltaTime);
        }        
        _rb.linearVelocity = currentVelocity;
    }
}
