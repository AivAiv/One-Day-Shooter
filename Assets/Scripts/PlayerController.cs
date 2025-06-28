using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Standard.Movement.performed += ctx =>
        {
            _moveInput = ctx.ReadValue<Vector2>();
        };
        _inputActions.Standard.Movement.canceled += _ => _moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void FixedUpdate() // 👈 use FixedUpdate for Rigidbody2D
    {
        _rb.velocity = _moveInput * moveSpeed;
    }
}