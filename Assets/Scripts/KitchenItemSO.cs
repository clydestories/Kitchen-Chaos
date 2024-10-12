using UnityEngine;

[CreateAssetMenu(fileName = "Kitchen Item", menuName = "Items", order = 3)]
public class KitchenItemSO : ScriptableObject
{
    [SerializeField] private KitchenItem _item;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;

    public KitchenItem Item => _item;
    public Sprite Sprite => _sprite;
    public string Name => _name;
}
