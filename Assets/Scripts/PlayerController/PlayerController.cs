using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private float _horizentalInput = 0.0f; // Inptu-State
    private float _coyoteTimeCounter = 0f; // State
    private float _jumpBufferCounter = 0f;// State
    private bool _isGrounded = false; // State
    private bool _wasGrounded = false; // State-History

    /// <summary>
    /// Transition
    /// </summary>
    private bool JustLanded => !_wasGrounded && _isGrounded;
    /// <summary>
    /// Transition
    /// </summary>
    private bool JustLeftGround => _wasGrounded && !_isGrounded;




    [Header("Dependencies")]
    [SerializeField] private MoveConfig _moveConfig;
    [SerializeField] private JumpConfig _jumpConfig;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GroundCheck _groundCheck;
    private MoveBehaviour _movement;
    private JumpBehaviour _jumpBehaviour;
    [Header("Options")]
    [SerializeField] private bool _jumpIsEnabled = true; //Rule
    [SerializeField] private bool _multiJumpEnabled = true; //RUle

    // --- Input ----
    private PlayerInputActions _inputActions;
    private InputAction _move;
    private InputAction _jump;



    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _move = _inputActions.Slime.Move;
        _jump = _inputActions.Slime.Jump;
        _movement = new MoveBehaviour(_moveConfig, _rb);
        _jumpBehaviour = new JumpBehaviour(_jumpConfig, _rb);
    }

    private void OnEnable()
    {
        _inputActions.Slime.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Slime.Disable();
    }

    private void FixedUpdate()
    {
        UpdateGroundState();// OK       
        ReduceCoyoteTimer();//OK
        ReduceJumpBuffer();
        HandleGroundTransition();//OK     
        _movement.SetGroundedState(_isGrounded);//OK
        HandleMovement();//OK
        HandleJump();
        
    }
    private void Update()
    {
        UpdateInput();

    }

    private void HandleGroundTransition()
    {
        if (JustLanded)
        {
            ResetGroundJumpCounter();
            ResetAirJumpCounter();
            Debug.Log("Player landed on Ground.");
        }
        if (JustLeftGround)
        {
            ResetCoyoteTimer();//OK
        }
    }

    public void UpdateInput()
    {
        _horizentalInput = _move.ReadValue<float>();

        if (_jump.WasPressedThisFrame())
        {
            ResetJumpBuffer();
        }
    }

    private void HandleJump()
    {
        if (!_jumpIsEnabled)
            return;

        if (_jumpBufferCounter <= 0f)
            return;

        if (_jumpBehaviour.Jump(_isGrounded, IsCoyoteTimeActive(), _multiJumpEnabled))
        {
            _jumpBufferCounter = 0f;

        }


    }
    private void HandleMovement()
    {
        _movement.Move(_horizentalInput);
    }

    private void ResetCoyoteTimer()
    {

        _coyoteTimeCounter = _jumpConfig.CoyoteTime;
        Debug.Log($" [CoyoteTime] reseted to [{_coyoteTimeCounter}].");

    }
    private void ResetAirJumpCounter()
    {
        _jumpBehaviour.ResetJumpCountAir();
        Debug.Log("[JumpCountAir] is reseted.");
    }

    private void ResetGroundJumpCounter()
    {
        _jumpBehaviour.ResetJumpCountGround();
        Debug.Log($"[JumpCountGround] is resetet.");
    }

    private void ReduceCoyoteTimer()
    {
        if (!_isGrounded && _coyoteTimeCounter > 0f)
        {
            _coyoteTimeCounter -= Time.deltaTime;
            Debug.Log($"[CoyoteTime] reduced to [{_coyoteTimeCounter}].");
        }
    }

    private bool IsCoyoteTimeActive()
    {
        return _coyoteTimeCounter > 0f;
    }

    private void UpdateGroundState()
    {
        _wasGrounded = _isGrounded;
        _isGrounded = _groundCheck.CheckGround();
    }

    private void ReduceJumpBuffer()
    {
        if (_jumpBufferCounter > 0f)
        {
            _jumpBufferCounter -= Time.deltaTime;
        }
    }
    private void ResetJumpBuffer()
    {
        _jumpBufferCounter = _jumpConfig.JumpBufferTime;
    }
}
