using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputReader : IInputReader
{
    public Vector3 MoveDirection { get; private set; }

    public NewInputReader()
    {
        var input = new GameInputActions();

        input.Player.Move.performed += HandleOnMovement;
        input.Player.Move.canceled += HandleOnMovement;

        input.Enable();
    }

    void HandleOnMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        MoveDirection = new Vector3(direction.x, 0, direction.y);
    }
}
