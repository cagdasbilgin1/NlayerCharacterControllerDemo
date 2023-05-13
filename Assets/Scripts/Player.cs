using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] bool _canMove;
    [SerializeField] float _speed = 5f;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    GameInputActions _input;
    Vector3 _movementDirection;

    void Awake()
    {
        _input = new GameInputActions();
    }

    void OnValidate()
    {
        if(_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }

        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void OnEnable()
    {
        _input.Player.Move.performed += HandleOnMovement;
        _input.Player.Move.canceled += HandleOnMovement;

        _input.Enable();
    }

    void OnDisable()
    {
        _input.Player.Move.performed -= HandleOnMovement;
        _input.Player.Move.canceled -= HandleOnMovement;

        _input.Disable();
    }

    void FixedUpdate()
    {
        if (!_canMove) return;

        _characterController.Move(_speed * _movementDirection * Time.deltaTime);
    }

    void LateUpdate()
    {
        _animator.SetFloat("Speed", _movementDirection.magnitude);
        _animator.SetFloat("DirectionX", _movementDirection.normalized.x, 0.05f, Time.deltaTime);
        _animator.SetFloat("DirectionY", _movementDirection.normalized.z, 0.05f, Time.deltaTime);
    }

    void HandleOnMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _movementDirection = new Vector3(direction.x, 0, direction.y);
    }
}
