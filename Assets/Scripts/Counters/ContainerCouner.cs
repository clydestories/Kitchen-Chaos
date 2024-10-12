using UnityEngine;

public class ContainerCouner : Counter
{
    [SerializeField] private KitchenItemSO _item;
    [SerializeField] private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite.sprite = _item.Sprite;
    }

    public override bool TryInteract(KitchenItem item)
    {
        return false;
    }

    public override KitchenItem Interact()
    {
        _animator.StartUseAnimation();
        return Instantiate(_item.Item);
    }
}
