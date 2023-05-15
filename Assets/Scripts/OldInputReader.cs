using UnityEngine;

public class OldInputReader : IInputReader
{
    public Vector3 MoveDirection
    {
        get
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            return new Vector3(x, 0, z);
        }
    }
}
