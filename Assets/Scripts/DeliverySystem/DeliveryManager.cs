using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private float _orderSpawnDelay;
    [SerializeField] private RecipeListSO _recipeList;

    private List<Order> _orders = new();
    private Coroutine _orderCreation;

    public event Action<Order> OrderCreated;
    public event Action<Order> OrderCompleted;

    private void OnEnable()
    {
        if (_orderCreation != null)
        {
            StopCoroutine(_orderCreation);
        }

        _orderCreation = StartCoroutine(CreatingOrders());
    }

    public bool TryRecieveOrder(Plate plate)
    {
        foreach (var order in _orders)
        {
            bool HasAllIngredients = true;

            foreach (var ingredient in order.RecipeSO.Ingredients)
            {
                if (plate.PlatedItems.Contains(ingredient) == false)
                {
                    HasAllIngredients = false;
                    break;
                }
            }

            if (HasAllIngredients)
            {
                _orders.Remove(order);
                OrderCompleted?.Invoke(order);
                return true;
            }
        }

        return false;
    }

    private IEnumerator CreatingOrders()
    {
        var wait = new WaitForSeconds(_orderSpawnDelay);

        while (enabled)
        { 
            yield return wait;
            CreateOrder();
        }

        _orderCreation = null;
    }

    private void CreateOrder()
    {
        int recipeIndex = UnityEngine.Random.Range(0, _recipeList.Recipes.Count);
        Order order = new Order(_recipeList.Recipes[recipeIndex]);
        _orders.Add(order);
        OrderCreated?.Invoke(order);
        Debug.Log(order.RecipeSO.Name);
    }
}
