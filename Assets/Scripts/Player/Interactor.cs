using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _interactDistance;
    [SerializeField] private LayerMask _interactableLayer;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;

    private Vector3 _currentLookDirection;
    private IInteractable _interactable;

    private void OnEnable()
    {
        _input.Interacted += Interact;
        _input.Moved += CheckForward;
    }

    private void OnDisable()
    {
        _input.Interacted -= Interact;
        _input.Moved -= CheckForward;
    }

    private void CheckForward(Vector2 lookDirection)
    {
        if (lookDirection != Vector2.zero)
        {
            _currentLookDirection = new Vector3(lookDirection.x, 0, lookDirection.y);
        }

        if (Physics.Raycast(
            transform.position + Vector3.up,
            _currentLookDirection,
            out RaycastHit hit,
            _interactDistance,
            _interactableLayer
            ))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (_interactable != interactable)
                {
                    if (_interactable != null)
                    {
                        _interactable.SetInactive();
                    }

                    _interactable = interactable;
                    _interactable.SetActive();
                    
                }

                return;
            }
        }

        _interactable?.SetInactive();

        _interactable = null;
    }

    private void Interact()
    {
        _interactable?.Interact();
    }
}
