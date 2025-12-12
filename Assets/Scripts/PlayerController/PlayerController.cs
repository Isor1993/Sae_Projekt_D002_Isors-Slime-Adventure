using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private float _horizentalInput = 0.0f;
    private bool _jumpPressed = false;
    private bool _isGrounded = false;
    private bool _wasGrounded = false;
    private float _coyoteTimeCounter;


    [Header("Dependencies")]
    [SerializeField] private MoveConfig _moveConfig;
    [SerializeField] private JumpConfig _jumpConfig;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GroundCheck _groundCheck;
    private MoveBehaviour _movement;
    private JumpBehaviour _jumpBehaviour;
    [Header("Options")]
    [SerializeField] private bool _jumpIsEnabled = true;

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
        _isGrounded = _groundCheck.CheckGround();

        if (!_wasGrounded && _isGrounded)
        {
            _jumpBehaviour._jumpCount = 0;
            _coyoteTimeCounter = _jumpConfig.CoyoteTime;
        }
        if (!_isGrounded) 
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }
        if (!_isGrounded && _coyoteTimeCounter <= 0f && _jumpBehaviour._jumpCount == 0)
        {
            _jumpBehaviour._jumpCount = 1;
        }

        
        _movement.SetGroundedState(_isGrounded);

        HandleMovement();
        HandleJump();
        _wasGrounded = _isGrounded;
    }

    private void Update()
    {
        UpdateInput();
        Debug.Log($"Jump is :[{IsCoyoteTimeActive()}] Counter:[{_coyoteTimeCounter}]");       
        Debug.Log(_jumpBehaviour._jumpCount);
        //Debug.Log(_jumpPressed);
        //Debug.Log(_isGrounded);

    }
    public void UpdateInput()
    {
        _horizentalInput = _move.ReadValue<float>();


        if (_jump.WasPressedThisFrame())
        {
            _jumpPressed = true;
        }
    }

    public void HandleMovement()
    {
        _movement.Move(_horizentalInput);
    }

    public void HandleJump()
    {
        if (_jumpIsEnabled && _jumpPressed)
        {


            bool jumped = _jumpBehaviour.Jump(_isGrounded, IsCoyoteTimeActive());
                      
                _jumpPressed = false;
            
            if (jumped && !_isGrounded)
            {
               
                _coyoteTimeCounter = 0f;
            }
        }
    }

    private bool IsCoyoteTimeActive()
    {
        return _coyoteTimeCounter > 0f;
    }
}
