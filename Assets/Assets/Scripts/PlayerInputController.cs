using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private Mover mover;

    private PlayerInputActions m_playerInputActions;

    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_playerInputActions.Player.Movement.Enable();
    }
    private void FixedUpdate()
    {
            Vector2 input = m_playerInputActions.Player.Movement.ReadValue<Vector2>();
            mover.Move(input);
    }
}