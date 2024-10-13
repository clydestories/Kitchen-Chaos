public class TrashCounter : Counter
{
    public override KitchenItem Interact()
    {
        return null;
    }

    public override bool TryInteract(KitchenItem item)
    {
        Destroy(item.gameObject);
        return true;
    }
}
