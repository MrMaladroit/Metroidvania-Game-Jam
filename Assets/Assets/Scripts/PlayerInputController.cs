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
    private InputAction m_attack;

    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_movement = m_playerInputActions.Player.Movement;
        m_jump = m_playerInputActions.Player.Jump;
        m_attack = m_playerInputActions.Player.Attack;
    }

    private void OnEnable()
    {
        m_movement.Enable();
        m_jump.Enable();
        m_attack.Enable();
    }
    private void OnDisable()
    {
        m_movement.Disable();
        m_jump.Disable();
        m_attack.Disable();
    }


    public void Jump_Performed(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            DoShortHop();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            m_jumper.isJumping = false;
        }

        //if (context.phase == InputActionPhase.Performed)
        //{
        //    if (context.interaction is TapInteraction)
        //    {
        //        DoShortHop();
        //    }
        //    else if (context.interaction is PressInteraction)
        //    {
        //        DoJump();
        //    }
        //}
        print(context.phase);
    }

    public void Attack_Performed(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            DoAttack();
    }

    private void DoAttack()
    {
        m_throwAttack.Lob();
    }

    private void DoJump()
    {
        m_jumper.Jump();
    }

    private void DoShortHop()
    {
        m_jumper.ShortHop();
    }

    private void FixedUpdate()
    {
        Vector2 input = m_movement.ReadValue<Vector2>();
        m_mover.Move(input);
    }
}