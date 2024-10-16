using UnityEngine;

public class PlateUI : MonoBehaviour
{
    [SerializeField] private Plate _plate;
    [SerializeField] private Icon _IconPrefab;
    [SerializeField] private Transform _iconGrid;

    private void OnEnable()
    {
        _plate.ContentAdded += UpdateUI;
    }

    private void OnDisable()
    {
        _plate.ContentAdded -= UpdateUI;
    }

    private void UpdateUI(KitchenItemSO newItem)
    {
        Icon icon = Instantiate(_IconPrefab, _iconGrid);
        icon.SetSprite(newItem.Sprite);
    }
}
