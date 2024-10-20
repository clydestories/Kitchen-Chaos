using UnityEngine;

public class DeliveryCounter : HolderCounter
{
    [SerializeField] private DeliveryManager _manager;

    public override bool TryInteract(KitchenItem item)
    {
        if (base.TryInteract(item))
        {
            SendDelivery();
            return true;
        }

        return false;
    }

    private void SendDelivery()
    {
        if (CurrentItem is Plate)
        {
            if (_manager.TryRecieveOrder(CurrentItem as Plate))
            {
                Destroy(CurrentItem.gameObject);
            }
        }
    }
}
