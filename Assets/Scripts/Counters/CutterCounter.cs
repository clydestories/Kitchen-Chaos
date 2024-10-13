using UnityEngine;

public class CutterCounter : HolderCounter, IUsable
{
    public void Use()
    {
        if (Item != null)
        {
            if (Item.ItemSO.SlicedItem != null)
            {
                KitchenItem slicedItem = Instantiate(Item.ItemSO.SlicedItem.Item, ItemHolder);
                Destroy(Item.gameObject);
                Item = slicedItem;
            }
        }
    }
}
