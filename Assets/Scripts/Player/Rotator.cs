using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;

    private void OnEnable()
    {
        _input.Moved += Rotate;
    }

    private void OnDisable()
    {
        _input.Moved -= Rotate;
    }

    private void Rotate(Vector2 inputDirection)
    {
        Vector3 lookDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        transform.forward = Vector3.Slerp(transform.forward, lookDirection, Time.deltaTime * _speed);
    }
}
