using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;

    private void OnEnable()
    {
        _input.Moved += Move;
    }

    private void OnDisable()
    {
        _input.Moved -= Move;
    }

    private void Move(Vector2 inputDirection)
    {
        Vector3 movingDirection = new Vector3(inputDirection.x, 0, inputDirection.y) * _speed * Time.deltaTime;
        transform.position += movingDirection;
    }
}
