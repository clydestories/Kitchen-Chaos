using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeList", menuName = "RecipeList", order = 5)]
public class RecipeListSO : ScriptableObject
{
    [SerializeField] private List<RecipeSO> _recipes = new();

    public List<RecipeSO> Recipes => _recipes.ToList();
}
