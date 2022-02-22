using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private Mover mover;

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
    }

    private void OnDisable()
    {
        m_movement.Disable();
    }
    private void FixedUpdate()
    {
            Vector2 input = m_movement.ReadValue<Vector2>();
            mover.Move(input);
    }
}