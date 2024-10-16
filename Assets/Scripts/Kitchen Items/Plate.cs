using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : KitchenItem
{
    [SerializeField] private RecipeListSO _recipeListSO;
    [SerializeField] private Transform _visualHolder;

    private List<KitchenItemSO> _platedItems = new();
    private List<RecipeSO> _potentialRecipes;
    private DishVisual _currentVisual;

    public event Action<KitchenItemSO> ContentAdded;

    public List<KitchenItemSO> PlatedItems => _platedItems.ToList();

    private void Start()
    {
        _potentialRecipes = _recipeListSO.Recipes;
    }

    public void PlateItem(KitchenItem item)
    {
        KitchenItemSO kitchenItemSO = item.ItemSO;
        Destroy(item.gameObject);
        _platedItems.Add(kitchenItemSO);
        UpdatePotentialRecipes(kitchenItemSO);
        UpdateVisual();
        ContentAdded?.Invoke(kitchenItemSO);
    }

    private void UpdatePotentialRecipes(KitchenItemSO item)
    {
        for (int i = _potentialRecipes.Count - 1; i >= 0; i--) 
        { 
            if (_potentialRecipes[i].Ingredients.Contains(item) == false)
            {
                _potentialRecipes.RemoveAt(i);
            }
        }
    }

    private void UpdateVisual()
    {
        if (_currentVisual != null) 
        {
            Destroy(_currentVisual.gameObject);
        }
        
        _currentVisual = Instantiate(_potentialRecipes[0].Visual, _visualHolder);
        _currentVisual.UpdateVisuals(_platedItems);
    }
}
