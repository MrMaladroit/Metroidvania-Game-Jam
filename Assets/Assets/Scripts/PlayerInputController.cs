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
    }

    private void OnEnable()
    {
        m_movement = m_playerInputActions.Player.Movement;
        m_movement.Enable();
        m_playerInputActions.Player.Jump.Enable();

        m_playerInputActions.Player.Jump.performed +=
            context =>
            {
                if (context.interaction is TapInteraction)
                {
                    DoShortHop();
                }
                else
                {
                    DoJump();
                }
            };

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