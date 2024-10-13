using UnityEngine;

public abstract class Counter : MonoBehaviour, IInteractable
{
    [SerializeField] protected CounterAnimator Animator;

    [SerializeField] private ActiveVisual _activeVisual;

    public abstract bool TryInteract(KitchenItem item);

    public abstract KitchenItem Interact();

    public void SetActive()
    {
        _activeVisual.gameObject.SetActive(true);
    }

    public void SetInactive() 
    {
        _activeVisual.gameObject.SetActive(false);
    }
}
