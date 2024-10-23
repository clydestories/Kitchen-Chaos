using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _playerRadius;
    [SerializeField] private float _playerHeight;
    [SerializeField] private float _collisionDistance;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;

    public event Action<Vector2> Moved;

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
        Vector3 topPlayerPoint = transform.position + Vector3.up * _playerHeight;

        if (Physics.CapsuleCast(transform.position, topPlayerPoint, _playerRadius, movingDirection, _collisionDistance) == false)
        {
            transform.position += movingDirection;
        }
        else if (Physics.CapsuleCast(transform.position, topPlayerPoint, _playerRadius, Vector3.right * movingDirection.x, _collisionDistance) == false)
        {
            transform.position += Vector3.right * movingDirection.x;
        }
        else if (Physics.CapsuleCast(transform.position, topPlayerPoint, _playerRadius, Vector3.forward * movingDirection.z, _collisionDistance) == false)
        {
            transform.position += Vector3.forward * movingDirection.z;
        }

        Moved?.Invoke(inputDirection);
    }
}
