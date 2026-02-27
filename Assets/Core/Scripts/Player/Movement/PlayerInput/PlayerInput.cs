using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    public event Action OnPlayerPressedJump;
    public event Action OnPlayerPressedSwitchSprint;

    private InputMap _inputMap;
    InputMap.PlayerActions _playerMap;
    
    [SerializeField] private PlayerMover _playerMover;

    void OnEnable() => _inputMap.Enable();
    void OnDisable() => _inputMap.Disable();

    private void Awake()
    {
        _inputMap = new InputMap();
        
        _playerMap = _inputMap.Player;
        
        _playerMover = GetComponent<PlayerMover>();
        
        _playerMap.Jump.performed += context => OnPlayerPressedJump?.Invoke();
        _playerMap.Sprint.performed += context => OnPlayerPressedSwitchSprint?.Invoke();
    }

    private void Update()
    {
        _playerMover.Move(_playerMap.Move.ReadValue<Vector2>());
    }
}