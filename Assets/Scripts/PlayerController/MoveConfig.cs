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

[CreateAssetMenu(fileName = "MoveConfig", menuName = "Scriptable Objects/MoveConfig")]
public class MoveConfig : ScriptableObject
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float maxSprintSpeed =7f;
    [SerializeField] float maxMoveSpeed = 2.5f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float deceleration = 20f;
    [SerializeField] float airAcceleration = 8f;
    [SerializeField] float airDeceleration = 2f;
    [SerializeField] float airControlFactor = 0.8f;   

    /// <summary>
    /// 
    /// </summary>
    public float MoveSpeed => moveSpeed;

    /// <summary>
    /// 
    /// </summary>
    public float SprintSpeed => sprintSpeed;

    /// <summary>
    /// 
    /// </summary>
    public float MaxSprintSpeed => maxSprintSpeed;

    /// <summary>
    /// 
    /// </summary>
    public float MaxSpeed => maxMoveSpeed;

    /// <summary>
    /// 
    /// </summary>
    public float Acceleration => acceleration;

    /// <summary>
    /// 
    /// </summary>
    public float Deceleration => deceleration;

    /// <summary>
    /// 
    /// </summary>
    public float AirAcceleration => airAcceleration;

    /// <summary>
    /// 
    /// </summary>
    public float AirDeceleration => airDeceleration;

    /// <summary>
    /// 
    /// </summary>
    public float AirControlFactor => airControlFactor;   
}
