using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 4)]
public class RecipeSO : ScriptableObject
{
    [SerializeField] private List<KitchenItemSO> _ingredients = new();
    [SerializeField] private string _name;
    [SerializeField] private DishVisual _visual;

    public List<KitchenItemSO> Ingredients => _ingredients;
    public string Name => _name;
    public DishVisual Visual => _visual;
}
