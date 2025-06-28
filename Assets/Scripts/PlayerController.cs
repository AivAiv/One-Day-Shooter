using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float deathAnimationTime = 5f;
    [SerializeField] private GameObject deathUI;
    
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    
    /// <summary>
    /// The inputs provided by the user
    /// </summary>
    public PlayerInputActions InputActions => _inputActions;

    public event Action<float, float> OnIdle;
    public event Action<float, float> OnWalk;
    public event Action OnDeath;

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
            if (_moveInput.x == 0 && _moveInput.y == 0) OnIdle?.Invoke(_moveInput.x, _moveInput.y);
            else OnWalk?.Invoke(_moveInput.x, _moveInput.y);
        };
        _inputActions.Standard.Movement.canceled += _ => _moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveInput * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Zombie")) return;
        OnDeath?.Invoke();
        _inputActions.Disable();
        StartCoroutine(StartDeathAnimation());
    }

    private IEnumerator StartDeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimationTime);
        deathUI.SetActive(true);
    }
}