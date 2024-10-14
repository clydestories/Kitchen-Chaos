using UnityEngine;

[CreateAssetMenu(fileName = "Kitchen Item", menuName = "Kitchen Item", order = 3)]
public class KitchenItemSO : ScriptableObject
{
    [SerializeField] private KitchenItem _item;
    [SerializeField] private KitchenItemSO _slicedItemSO;
    [SerializeField] private int _slicingToughness;
    [SerializeField] private KitchenItemSO _cookedItemSO;
    [SerializeField] private float _cookTime;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private bool _canBePlated;

    public KitchenItem Item => _item;
    public KitchenItemSO SlicedItem => _slicedItemSO;
    public int SlicingToughness => _slicingToughness;
    public KitchenItemSO CookedItemSO => _cookedItemSO;
    public float CookTime => _cookTime;
    public Sprite Sprite => _sprite;
    public string Name => _name;
    public bool CanBePlated => _canBePlated;
}
