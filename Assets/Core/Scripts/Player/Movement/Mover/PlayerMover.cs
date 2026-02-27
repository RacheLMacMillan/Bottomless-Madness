using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerSprinter))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _MaxSpeed;
    [SerializeField, Range(1, 3)] private float _sprintingMultiplier;

    private Rigidbody2D _rigidbody;
    private PlayerSprinter _sprinter;

    private bool _isSprinting;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprinter = GetComponent<PlayerSprinter>();
    }

    private void OnEnable() => _sprinter.OnPlayerSprinting += IsSprinting;
    private void OnDisable() => _sprinter.OnPlayerSprinting -= IsSprinting;

    public void Move(Vector2 direction)
    {
        float scaleMoveSpeed = 0;
    
        if (_isSprinting)
            scaleMoveSpeed  = _MaxSpeed * _sprintingMultiplier * Time.deltaTime;
        else
            scaleMoveSpeed  = _MaxSpeed * Time.deltaTime;
        
        Vector2 newDirection = new Vector2(direction.x * scaleMoveSpeed, 0);
        
        transform.position += new Vector3(newDirection.x, 0, 0);
    }
    
    private void IsSprinting(bool isSprinting)
    {
        _isSprinting = isSprinting;
    }
}