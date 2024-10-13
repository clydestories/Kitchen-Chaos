using UnityEngine;

public class KitchenItem : MonoBehaviour, IHoldable
{
    [SerializeField] private KitchenItemSO _itemSO;

    private int _slicesRemaining;

    public KitchenItemSO ItemSO => _itemSO;
    public int SlicesRemaining => _slicesRemaining;

    private void Start()
    {
        _slicesRemaining = _itemSO.SlicingToughness;
    }

    public void GetSliced()
    {
        _slicesRemaining--;
    }
}
