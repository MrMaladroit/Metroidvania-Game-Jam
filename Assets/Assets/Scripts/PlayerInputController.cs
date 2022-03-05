using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private Mover m_mover;
    [SerializeField]
    private Jumper m_jumper;
    [SerializeField]
    private ThrowAttack m_throwAttack;

    private PlayerInputActions m_playerInputActions;
    private InputAction m_movement;
    private InputAction m_jump;
    private InputAction m_throw;
    private InputAction m_lob;

    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_movement = m_playerInputActions.Player.Movement;
        m_jump = m_playerInputActions.Player.Jump;
        m_throw = m_playerInputActions.Player.ThrowAttack;
        m_lob = m_playerInputActions.Player.LobAttack;
    }

    private void OnEnable()
    {
        m_movement.Enable();
        m_jump.Enable();
        m_throw.Enable();
        m_lob.Enable();
    }
    private void OnDisable()
    {
        m_movement.Disable();
        m_jump.Disable();
        m_throw.Disable();
        m_lob.Disable();
    }


    public void Jump_Performed(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            DoJump();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            m_jumper.isJumping = false;
        }
    }

    public void Throw_Attack_Performed(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            DoThrowAttack();
    }

    public void Lob_Attack_Performed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            DoLobAttack();
    }

    private void DoLobAttack()
    {
        m_throwAttack.Lob();
    }

    private void DoThrowAttack()
    {
        m_throwAttack.Throw();
    }

    private void DoJump()
    {
        m_jumper.Jump();
    }

    private void FixedUpdate()
    {
        Vector2 input = m_movement.ReadValue<Vector2>();
        m_mover.Move(input);
    }
}