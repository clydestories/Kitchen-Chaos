using UnityEngine;

public class KitchenItem : MonoBehaviour, IHoldable
{
    [SerializeField] private KitchenItemSO _itemSO;

    public KitchenItemSO ItemSO => _itemSO;
}
