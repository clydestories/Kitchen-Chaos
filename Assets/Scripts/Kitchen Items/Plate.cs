using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenItem
{
    private List<KitchenItem> _platedItems = new List<KitchenItem>();

    public void PlateItem(KitchenItem item)
    {
        item.transform.parent = transform;
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        _platedItems.Add(item);
    }
}
