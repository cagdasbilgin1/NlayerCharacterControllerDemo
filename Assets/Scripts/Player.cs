using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;

    [SerializeField] bool _canMove;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    IMoveService _moveService;

    public bool CanMove => _canMove;
    public Animator Animator => _animator;

    public IInputReader InputReader { get; private set; }

    void Awake()
    {
        InputReader = new OldInputReader();
        _moveService = new PlayerMoveManager(this);
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

    void Update()
    {
        _moveService.Tick();
    }

    void FixedUpdate()
    {
        _moveService.FixedTick();
    }

    void LateUpdate()
    {
        _moveService.LateTick();
    }
}
