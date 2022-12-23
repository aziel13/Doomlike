using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerInput;
    public PlayerControls.WalkingActions walkingActions;

    private PlayerMovement _motor;
    private PlayerLook _look;
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _playerInput = new PlayerControls();
        walkingActions = _playerInput.walking;

        _motor = GetComponent<PlayerMovement>();
        _look = GetComponent<PlayerLook>();
        walkingActions.jump.performed += ctx => _motor.Jump();
        walkingActions.crouch.performed += ctx => _motor.Crouch();
        walkingActions.sprint.performed += ctx => _motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _motor.ProcessMove(walkingActions.horrizontalMove.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(walkingActions.camMovement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        walkingActions.Enable();
    }

    private void OnDisable()
    {
        walkingActions.Disable();
    }
}
