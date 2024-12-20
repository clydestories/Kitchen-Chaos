using UnityEngine;

public class ContainerCouner : Counter, IGivable
{
    [SerializeField] private KitchenItemSO _item;
    [SerializeField] private SpriteRenderer _sprite;

    private void Start()
    {
        if (_sprite != null)
        {
            _sprite.sprite = _item.Sprite;
        }
    }

    public override bool TryInteract(KitchenItem item)
    {
        return false;
    }

    public override KitchenItem Interact()
    {
        Animator?.StartUseAnimation();
        AudioHandler.PlayInteractGiveSound();
        return Instantiate(_item.Item);
    }

    public KitchenItem GetItem()
    {
        return _item.Item;
    }
}
