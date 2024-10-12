public interface IInteractable
{
    public abstract bool TryInteract(KitchenItem item);
    public abstract KitchenItem Interact();

    public abstract void SetActive();

    public abstract void SetInactive();
}
