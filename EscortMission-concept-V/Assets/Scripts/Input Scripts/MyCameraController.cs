using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCameraController : MonoBehaviour {
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    [SerializeField] private float _cameraMoveSpeed = 0.2f;

    private bool _keyIsPressed = false;

    void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    void OnEnable() {
        _moveAction.started += MoveCamera;
        _moveAction.canceled += StopMovingCamera;
    }

    void OnDisable() {
        _moveAction.started -= MoveCamera;
        _moveAction.canceled -= StopMovingCamera;
    }

    private void MoveCamera(InputAction.CallbackContext context) {
        _keyIsPressed = true;
        //transform.Translate(context.ReadValue<Vector3>());
    }

    private void StopMovingCamera(InputAction.CallbackContext context) {
        _keyIsPressed = false;
    }

    void FixedUpdate() {
        if(_keyIsPressed) {
            transform.Translate(_moveAction.ReadValue<Vector3>() * _cameraMoveSpeed);
        }
    }

}
