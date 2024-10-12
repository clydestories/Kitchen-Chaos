using UnityEngine;

public class HolderCounter : Counter
{
    [SerializeField] private Transform _itemHolder;

    private KitchenItem _item;

    public override bool TryInteract(KitchenItem item)
    {
        if (_item == null)
        {
            PlaceItem(item);
            return true;
        }

        return false;
    }

    public override KitchenItem Interact()
    {
        if (_item != null)
        {
            return GiveItem();
        }

        return null;
    }

    private void PlaceItem(KitchenItem item)
    {
        _item = item;
        _item.transform.parent = _itemHolder;
        _item.transform.localPosition = Vector3.zero;
        _item.transform.localEulerAngles = Vector3.zero;
    }

    private KitchenItem GiveItem()
    {
        KitchenItem itemToGive = _item;
        _item = null;
        return itemToGive;
    }
}
