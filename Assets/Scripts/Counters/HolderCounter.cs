using UnityEngine;

public class HolderCounter : Counter, IGivable
{
    [SerializeField] protected Transform ItemHolder;

    protected KitchenItem CurrentItem;

    public override bool TryInteract(KitchenItem item)
    {
        if (CurrentItem == null)
        {
            PlaceItem(item);
            return true;
        }
        else if (CurrentItem is Plate && item.ItemSO.CanBePlated) 
        { 
            Plate plate = (Plate)CurrentItem;

            if (plate.PlatedItems.Contains(item.ItemSO) == false)
            {
                plate.PlateItem(item);
                return true;
            }
        }

        return false;
    }

    public override KitchenItem Interact()
    {
        if (CurrentItem != null)
        {
            return GiveItem();
        }

        return null;
    }

    protected void PlaceItem(KitchenItem item)
    {
        CurrentItem = item;
        CurrentItem.transform.parent = ItemHolder;
        CurrentItem.transform.localPosition = Vector3.zero;
        CurrentItem.transform.localEulerAngles = Vector3.zero;
    }

    private KitchenItem GiveItem()
    {
        KitchenItem itemToGive = CurrentItem;
        CurrentItem = null;
        return itemToGive;
    }

    public KitchenItem GetItem()
    {
        return CurrentItem;
    }
}
