using UnityEngine;

public class HolderCounter : Counter
{
    [SerializeField] protected Transform ItemHolder;

    protected KitchenItem Item;

    public override bool TryInteract(KitchenItem item)
    {
        if (Item == null)
        {
            PlaceItem(item);
            return true;
        }

        return false;
    }

    public override KitchenItem Interact()
    {
        if (Item != null)
        {
            return GiveItem();
        }

        return null;
    }

    private void PlaceItem(KitchenItem item)
    {
        Item = item;
        Item.transform.parent = ItemHolder;
        Item.transform.localPosition = Vector3.zero;
        Item.transform.localEulerAngles = Vector3.zero;
    }

    private KitchenItem GiveItem()
    {
        KitchenItem itemToGive = Item;
        Item = null;
        return itemToGive;
    }
}
