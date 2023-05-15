using UnityEngine;

public class CharacterControllerMoverDal : IMoverDal
{
    readonly CharacterController _characterController;
    readonly float _speed;

    public CharacterControllerMoverDal(Transform transform, float speed)
    {
        _characterController = transform.GetComponent<CharacterController>();
        _speed = speed;
    }    

    public void FixedTick(Vector3 moveDirection)
    {
        _characterController.Move(_speed * moveDirection * Time.deltaTime);
    }
}
