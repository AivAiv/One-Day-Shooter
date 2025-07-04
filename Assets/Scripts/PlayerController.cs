using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float deathAnimationTime = 5f;
    [SerializeField] private GameObject deathUI;
    public bool IsDead;
    [SerializeField] private GameObject HUD;
    
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
            OnWalk?.Invoke(_moveInput.x, _moveInput.y);
        };
        _inputActions.Standard.Movement.canceled += _ => { _moveInput = Vector2.zero; OnIdle?.Invoke(_moveInput.x, _moveInput.y); };
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
        _inputActions.Disable();
        IsDead = true;
        OnDeath?.Invoke();
        StartCoroutine(StartDeathAnimation());
    }

    private IEnumerator StartDeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimationTime);
        HUD.SetActive(false);
        deathUI.SetActive(true);
    }
}