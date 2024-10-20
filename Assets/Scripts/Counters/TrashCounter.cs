using UnityEngine;

public class TrashCounter : Counter, ITakeable
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
