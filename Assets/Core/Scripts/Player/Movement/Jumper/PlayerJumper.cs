using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _playerInput.OnPlayerPressedJump += Jump;
    private void OnDisable() => _playerInput.OnPlayerPressedJump -= Jump;
    
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}