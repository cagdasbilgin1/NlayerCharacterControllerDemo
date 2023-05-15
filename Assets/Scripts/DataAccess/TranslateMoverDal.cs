using UnityEngine;

public class TranslateMoverDal : IMoverDal
{
    readonly Transform _transform;
    readonly float _speed;

    public TranslateMoverDal(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public void FixedTick(Vector3 moveDirection)
    {
        _transform.Translate(_speed * moveDirection * Time.deltaTime);
    }
}
