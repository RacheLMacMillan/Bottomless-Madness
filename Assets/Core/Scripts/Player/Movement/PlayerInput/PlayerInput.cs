using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private InputMap _inputMap;
    InputMap.PlayerActions _playerMap;
    
    private PlayerMover _playerMover;

    void OnEnable()
    {
        _inputMap.Enable();
    }

    void OnDisable()
    {
        _inputMap.Disable();
    }

    private void Awake()
    {
        _inputMap = new InputMap();
        
        _playerMap = _inputMap.Player;
        
        _playerMover = GetComponent<PlayerMover>();
        
    }

    private void Update()
    {
        _playerMover.Move(_playerMap.Move.ReadValue<Vector2>());
    }
}