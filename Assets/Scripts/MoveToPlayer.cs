using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D _rb;
    private PlayerController _playerController;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _playerController = _player.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (_playerController.IsDead) return;

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _rb.velocity = direction * moveSpeed;
    }
}