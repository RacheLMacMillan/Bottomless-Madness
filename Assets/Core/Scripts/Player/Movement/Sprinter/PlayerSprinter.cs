using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerSprinter : MonoBehaviour
{
    public event Action<bool> OnPlayerSprinting;
    
    private PlayerInput _playerInput;
    
    [SerializeField, Range(1, 3)] private float _sprintMultiplier;
    
    private bool _isSprinting;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable() => _playerInput.OnPlayerPressedSwitchSprint += SwitchSprint;
    private void OnDisable() => _playerInput.OnPlayerPressedSwitchSprint -= SwitchSprint;

    private void SwitchSprint()
    {
        _isSprinting = !_isSprinting;
    
        OnPlayerSprinting?.Invoke(_isSprinting);
    }
}