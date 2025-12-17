using UnityEngine;

[CreateAssetMenu(fileName = "MoveConfig", menuName = "Scriptable Objects/MoveConfig")]
public class MoveConfig : ScriptableObject
{

    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float sprintSpeed = 10f;
    [SerializeField] float maxSprintSpeed =11f;
    [SerializeField] float maxMoveSpeed = 1.5f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float deceleration = 20f;
    [SerializeField] float airAcceleration = 8f;
    [SerializeField] float airDeceleration = 2f;
    [SerializeField] float airControlFactor = 0.8f;
    [SerializeField] float velocitySmoothing = 0.05f;
    public float MoveSpeed => moveSpeed;

    public float SprintSpeed => sprintSpeed;

    public float MaxSprintSpeed => maxSprintSpeed;

    public float MaxSpeed => maxMoveSpeed;

    public float Acceleration => acceleration;

    public float Deceleration => deceleration;

    public float AirAcceleration => airAcceleration;

    public float AirDeceleration => airDeceleration;

    public float AirControlFactor => airControlFactor;

    public float VelocitySmoothing => velocitySmoothing;
}
