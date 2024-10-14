using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishVisual : MonoBehaviour
{
    [SerializeField] private List<KitchenItemSO_VisualGO> _visuals = new();

    public List<KitchenItemSO_VisualGO> Visuals => _visuals.ToList();

    private void OnEnable()
    {
        foreach (var visual in _visuals)
        {
            visual.ItemGO.SetActive(false);
        }
    }

    public void UpdateVisuals(List<KitchenItemSO> ingredients)
    {
        foreach (var visual in _visuals) 
        {
            foreach(var ingredient in ingredients)
            {
                if (visual.ItemSO == ingredient)
                {
                    visual.ItemGO.SetActive(true);
                }
            }
        }
    }
}
