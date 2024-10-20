using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dishName;
    [SerializeField] private Transform _ingredientContainer;
    [SerializeField] private Icon _iconPrefab;

    public string DishName => _dishName.text;

    public void Construct(string dishName, List<KitchenItemSO> ingredients)
    {
        _dishName.text = dishName;

        foreach (var item in ingredients)
        {
            Icon newIcon = Instantiate(_iconPrefab, _ingredientContainer);
            newIcon.SetSprite(item.Sprite);
        }
    }
}
