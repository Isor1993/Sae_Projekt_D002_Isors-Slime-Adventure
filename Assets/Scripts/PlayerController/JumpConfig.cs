using UnityEngine;

[CreateAssetMenu(fileName = "JumpConfig", menuName = "Scriptable Objects/JumpConfig")]
public class JumpConfig : ScriptableObject
{
    [SerializeField] private float _jumpforce = 1;
    [SerializeField] private float _gravityScaleUp;
    [SerializeField] private float _gravityScaleDown;
    [SerializeField] private float _jumpCutMultiplier;
    [SerializeField] private float _coyoteTime;
    [SerializeField] private float _jumpBufferTime;
    [SerializeField] private float _multiJumpCount;
       

    public float JumpForce =>_jumpforce;

    public float GravityScaleUp =>_gravityScaleUp;

    public float GravityScaleDown =>_gravityScaleDown;

    public float JumpCutMultiplier =>_jumpCutMultiplier;

    public float JumpBufferTime =>_jumpBufferTime;  

    public float MultiJumpCount =>_multiJumpCount;
}
