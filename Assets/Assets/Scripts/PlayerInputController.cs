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
        m_playerInputActions.Player.Enable();
    }
    private void Update()
    {
        if (m_playerInputActions.Player.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            Vector2 input = m_playerInputActions.Player.Movement.ReadValue<Vector2>();
            mover.Move(input);

        }
    }
}