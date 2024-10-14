using UnityEngine;

public class KitchenItem : MonoBehaviour, IHoldable
{
    [SerializeField] private KitchenItemSO _itemSO;

    private int _slicesRemaining;
    private float _cookingProgress;

    public KitchenItemSO ItemSO => _itemSO;
    public int SlicesRemaining => _slicesRemaining;
    public float CookingProgress => _cookingProgress;

    private void Start()
    {
        _slicesRemaining = _itemSO.SlicingToughness;
    }

    public void GetSliced()
    {
        _slicesRemaining--;
    }

    public void GetCooked(float amount)
    {
        _cookingProgress += amount;
    }
}
