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

[CreateAssetMenu(fileName = "JumpConfig", menuName = "Scriptable Objects/JumpConfig")]
public class JumpConfig : ScriptableObject
{

    [SerializeField] private float _jumpforce = 5;
    [SerializeField] private float _coyoteTime = 0.2f;
    [SerializeField] private float _jumpBufferTime = 0.15f;
    [SerializeField] private int _maxJumpCountAir = 1;


    /// <summary>
    /// 
    /// </summary>
    public float JumpForce => _jumpforce;

    /// <summary>
    /// 
    /// </summary>
    public float JumpBufferTime => _jumpBufferTime;

    /// <summary>
    /// 
    /// </summary>
    public int MaxJumpCountAir => _maxJumpCountAir;

    /// <summary>
    /// 
    /// </summary>
    public float CoyoteTime => _coyoteTime;
}
