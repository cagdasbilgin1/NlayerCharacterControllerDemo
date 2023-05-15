using UnityEngine;

public class PlayerMoveManager : IMoveService
{
    readonly IMoverDal _moverDal;
    readonly Player _player;
    Vector3 _moveDirection;
    Animator _animator;

    public PlayerMoveManager(Player player)
    {
        _moverDal = new CharacterControllerMoverDal(player.transform, player.Speed);
        _player = player;
        _animator = player.Animator;
    }
    public void Tick()
    {
        _moveDirection = _player.InputReader.MoveDirection;
    }
    public void FixedTick()
    {
        if (!_player.CanMove) return;

        _moverDal.FixedTick(_moveDirection);
    }

    public void LateTick()
    {
        _animator.SetFloat("Speed", _moveDirection.magnitude);
        _animator.SetFloat("DirectionX", _moveDirection.normalized.x, 0.05f, Time.deltaTime);
        _animator.SetFloat("DirectionY", _moveDirection.normalized.z, 0.05f, Time.deltaTime);
    }
}
