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

    private PlayerInputActions m_playerInputActions;
    private InputAction m_movement;

    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_movement = m_playerInputActions.Player.Movement;
    }

    private void OnEnable()
    {
        m_movement.Enable();
    }


    public void Jump_Performed(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if(context.interaction is TapInteraction)
            {
                DoShortHop();
            }
            else if(context.interaction is PressInteraction)
            {
                DoJump();
            }
        }
        print(context.phase);
    }

    private void DoJump()
    {
        m_jumper.Jump();
    }

    private void DoShortHop()
    {
        m_jumper.ShortHop();
    }

    private void OnDisable()
    {
        m_movement.Disable();
    }
    private void FixedUpdate()
    {
            Vector2 input = m_movement.ReadValue<Vector2>();
            m_mover.Move(input);
    }
}