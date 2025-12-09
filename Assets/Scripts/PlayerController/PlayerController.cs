using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private float _horizentalInput = 0.0f;
    private bool _jumpPressed = false;
    private bool _jumpReleased = true;
    private bool _jumpHeld = false;
    private bool _isGrounded = false;

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
        _jumpBehaviour = new JumpBehaviour(_jumpConfig,_rb);



    }

    private void OnEnable()
    {
        _inputActions.Slime.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Slime.Disable();
    }


    private void Start()
    {

    }
    private void FixedUpdate()
    {
        bool _oldIsGrounded= _isGrounded;
        bool _oldJumpPressed = _jumpPressed;
        _isGrounded = _groundCheck.CheckGround();
        if (_isGrounded != _oldIsGrounded)
        {

            Debug.Log($"_isGrounded: {_isGrounded}");
        }
        if (_jumpPressed != _oldJumpPressed)
        {
            Debug.Log($"_jumpPressed: {_jumpPressed}");
        }
        HandleMovement();
        HandleJump();

    }

    private void Update()
    {
        UpdateInput();

    }
    public void UpdateInput()
    {
        _horizentalInput = _move.ReadValue<float>();

        _jumpPressed = _jump.IsPressed();

    }
    public void HandleMovement()
    {
        _movement.Move(_horizentalInput);
        Debug.Log(_rb.linearVelocityX);
    }

    public void HandleJump()
    {
        if (_jumpIsEnabled && _jumpPressed && _isGrounded)
        {
            _jumpBehaviour.Jump();
        }

    }
}
