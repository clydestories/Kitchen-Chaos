using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _interactDistance;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;

    private Vector3 _currentLookDirection;

    private void OnEnable()
    {
        _input.Interacted += Interact;
    }

    private void OnDisable()
    {
        _input.Interacted += Interact;
    }

    private void Interact(Vector2 lookDirection)
    {
        if (lookDirection != Vector2.zero)
        {
            _currentLookDirection = new Vector3(lookDirection.x, 0, lookDirection.y);
        }

        if (Physics.Raycast(transform.position + Vector3.up, _currentLookDirection, out RaycastHit hit, _interactDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
