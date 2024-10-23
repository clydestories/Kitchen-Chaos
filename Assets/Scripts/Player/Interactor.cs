using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _interactDistance;
    [SerializeField] private LayerMask _interactableLayer;
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;
    [SerializeField] private Transform _itemHolder;

    private Vector3 _currentLookDirection;
    private IInteractable _interactable;
    private KitchenItem _itemInHands;

    private void OnEnable()
    {
        _input.Interacted += Interact;
        _input.Moved += CheckForward;
        _input.Used += Use;
    }

    private void OnDisable()
    {
        _input.Interacted -= Interact;
        _input.Moved -= CheckForward;
        _input.Used -= Use;
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

    private void Use()
    {
        if (_interactable != null && _interactable is IUsable)
        {
            IUsable usable = _interactable as IUsable;
            usable.Use();
        }
    }

    private void Interact()
    {
        if (_interactable is HolderCounter)
        {
            HolderCounter holderCounter = _interactable as HolderCounter;

            if (holderCounter.GetItem() == null || holderCounter.GetItem() is Plate && _itemInHands != null)
            {
                PutItem();
            }
            else if (_itemInHands is Plate)
            {
                if (holderCounter.GetItem().ItemSO.CanBePlated)
                {
                    TakeItem();
                }
            }
            else if (_itemInHands == null)
            {
                TakeItem();
            }
        }
        else if (_interactable is IGivable)
        {
            IGivable givable = _interactable as IGivable;

            if (_itemInHands is Plate)
            {
                if (givable.GetItem().ItemSO.CanBePlated)
                {
                    TakeItem();
                }
            }
            else if (_itemInHands == null)
            {
                TakeItem();
            }
            else if (_itemInHands != null && givable is PlatingCounter)
            {
                if (_itemInHands.ItemSO.CanBePlated)
                {
                    KitchenItem tempItem = _itemInHands;
                    _itemInHands = null;
                    TakeItem();
                    Plate plate = _itemInHands as Plate;
                    plate.PlateItem(tempItem);
                }
            }
        }
        else if (_interactable is ITakeable)
        {
            if (_itemInHands != null)
            {
                PutItem();
            }
        }
    }

    private void PutItem()
    {
        if (_itemInHands != null)
        {
            if (_interactable != null && _interactable.TryInteract(_itemInHands))
            {
                _itemInHands = null;
            }
        }
    }

    private void TakeItem()
    {
        KitchenItem newItem;
        IGivable givable = _interactable as IGivable;

        if (_itemInHands is Plate)
        {
            Plate plate = _itemInHands as Plate;

            if (plate.PlatedItems.Contains(givable.GetItem().ItemSO) == false) 
            {
                newItem = _interactable?.Interact();

                if (newItem != null) 
                {
                    plate.PlateItem(newItem);
                }
            }
        }
        else
        {
            _itemInHands = _interactable?.Interact();

            if (_itemInHands != null)
            {
                _itemInHands.transform.parent = _itemHolder;
                _itemInHands.transform.localPosition = Vector3.zero;
                _itemInHands.transform.localEulerAngles = Vector3.zero;
            }
        }
    }
}
