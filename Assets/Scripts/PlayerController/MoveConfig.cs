using UnityEngine;

[CreateAssetMenu(fileName = "MoveConfig", menuName = "Scriptable Objects/MoveConfig")]
public class MoveConfig : ScriptableObject
{

    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float maxSpeed = 1.5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 10f;
    [SerializeField] float airAcceleration = 8f;
    [SerializeField] float airDeceleration = 8f;
    [SerializeField] float airControlFactor = 0.8f;
    [SerializeField] float velocitySmoothing = 0.05f;
    public float MoveSpeed => moveSpeed;

    public float MaxSpeed => maxSpeed;

    public float Acceleration => acceleration;

    public float Deceleration => deceleration;

    public float AirAcceleration => airAcceleration;

    public float AirDeceleration => airDeceleration;

    public float AirControlFactor => airControlFactor;

    public float VelocitySmoothing => velocitySmoothing;
}
