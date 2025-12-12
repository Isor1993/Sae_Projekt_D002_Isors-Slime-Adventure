using UnityEngine;

[CreateAssetMenu(fileName = "JumpConfig", menuName = "Scriptable Objects/JumpConfig")]
public class JumpConfig : ScriptableObject
{
    [SerializeField] private float _jumpforce = 5;
    [SerializeField] private float _gravityScaleUp;
    [SerializeField] private float _gravityScaleDown;
    [SerializeField] private float _jumpCutMultiplier;
    [SerializeField] private float _coyoteTime = 0.1f;
    [SerializeField] private float _jumpBufferTime;
    [Tooltip("Always -1 because ")]
    [SerializeField] private float _maxJumpCount = 2;
    [SerializeField] private float _multiJumpCountAir = 1;


    public float JumpForce => _jumpforce;

    public float GravityScaleUp => _gravityScaleUp;

    public float GravityScaleDown => _gravityScaleDown;

    public float JumpCutMultiplier => _jumpCutMultiplier;

    public float JumpBufferTime => _jumpBufferTime;

    public float MaxJumpCount => _maxJumpCount;
   
    public float CoyoteTime => _coyoteTime;
}
