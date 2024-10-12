using UnityEngine;

public abstract class Counter : MonoBehaviour, IInteractable
{
    [SerializeField] private ActiveVisual _activeVisual;

    public abstract void Interact();

    public void SetActive()
    {
        _activeVisual.gameObject.SetActive(true);
    }

    public void SetInactive() 
    {
        _activeVisual.gameObject.SetActive(false);
    }
}
