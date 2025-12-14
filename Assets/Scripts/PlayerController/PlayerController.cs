using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private float _horizentalInput = 0.0f; // Inptu-State
    private float _coyoteTimeCounter = 0f; // State
    private float _jumpBufferCounter = 0f;// State
    private bool _isGrounded = false; // State
    private bool _wasGrounded = false; // State-History
    private bool _isTouchingWall = false; //State
    private bool _wasTouchingWall = false; //State-History

    /// <summary>
    /// Transition
    /// </summary>
    public bool JustLanded => !_wasGrounded && _isGrounded;
    /// <summary>
    /// Transition
    /// </summary>
    public bool JustLeftGround => _wasGrounded && !_isGrounded;
    public bool JustHitWall => !_wasTouchingWall && _isTouchingWall;
    public bool JustLeftWall => _wasTouchingWall && !_isTouchingWall;




    [Header("Dependencies")]
    [SerializeField] private MoveConfig _moveConfig;
    [SerializeField] private JumpConfig _jumpConfig;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private WallCheck _wallCheck;
    private MoveBehaviour _movement;
    private JumpBehaviour _jumpBehaviour;
    [Header("Options")]
    [SerializeField] private bool _jumpIsEnabled = true; //Rule
    [SerializeField] private bool _multiJumpEnabled = true; //RUle
    [SerializeField] private bool _wallJumpEnabled = true; //Rule

    // --- Input ----
    private PlayerInputActions _inputActions;
    private InputAction _move;
    private InputAction _jump;



    private void Awake()
    {
        _inputActions = new PlayerInputActions();// OK
        _move = _inputActions.Slime.Move;// OK
        _jump = _inputActions.Slime.Jump;// OK
        _movement = new MoveBehaviour(_moveConfig, _rb);// OK
        _jumpBehaviour = new JumpBehaviour(_jumpConfig, _rb);// OK
    }

    private void OnEnable()
    {
        _inputActions.Slime.Enable();// OK
    }

    private void OnDisable()
    {
        _inputActions.Slime.Disable();// OK
    }

    private void FixedUpdate()
    {
        UpdateGroundState();// OK
        UpdateWallState();   // OK         
        ReduceCoyoteTimer();//OK
        ReduceJumpBuffer();// OK
        HandleGroundTransition();//OK
        HandleWallTransition();   // OK                   
        _movement.SetGroundedState(_isGrounded);//OK
        HandleMovement();//OK
        HandleJump();// OK

    }
    private void Update()
    {
        UpdateInput();// OK

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
    private void HandleWallTransition()
    {
        if (JustHitWall)
        {
            
            ResetAirJumpCounter();
            Debug.Log("Player landed on Wall.");
        }
        if (JustLeftWall)
        {
           
            ResetCoyoteTimer();
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

        if (_jumpBehaviour.Jump(_isGrounded, IsCoyoteTimeActive(), _multiJumpEnabled,_isTouchingWall,_wallJumpEnabled))
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
        //Debug.Log($" [CoyoteTime] reseted to [{_coyoteTimeCounter}].");

    }
    private void ResetAirJumpCounter()
    {
        _jumpBehaviour.ResetJumpCountAir();
        Debug.Log("[JumpCountAir] is reseted.");
    }

    private void ResetGroundJumpCounter()
    {
        _jumpBehaviour.ResetJumpCountGround();
        Debug.Log($"[JumpCountGround] is reseted.");
    }

    private void ReduceCoyoteTimer()
    {
        if ((!_isGrounded && !_isTouchingWall) && _coyoteTimeCounter > 0f)
        {
            _coyoteTimeCounter -= Time.deltaTime;
            //Debug.Log($"[CoyoteTime] reduced to [{_coyoteTimeCounter}].");
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
    private void UpdateWallState()
    {
        _wasTouchingWall = _isTouchingWall;
        _isTouchingWall = _wallCheck.CheckWall();
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
