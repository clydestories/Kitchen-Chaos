using UnityEngine;

public class TrashCounter : Counter, ITakeable
{
    public override KitchenItem Interact()
    {
        return null;
    }

    public override bool TryInteract(KitchenItem item)
    {
        Debug.Log("qwe");
        Destroy(item.gameObject);
        return true;
    }
}
