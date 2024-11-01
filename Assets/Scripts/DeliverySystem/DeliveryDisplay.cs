using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryDisplay : MonoBehaviour
{
    [SerializeField] private DeliveryManager _deliveryManager;
    [SerializeField] private Transform _ordersContainer;
    [SerializeField] private OrderUI _orderPrefab;
    [SerializeField] private float _scaleDuration;

    private List<OrderUI> _orders = new();

    private void OnEnable()
    {
        _deliveryManager.OrderCreated += AddOrder;
        _deliveryManager.OrderCompleted += RemoveOrder;
    }

    private void OnDisable()
    {
        _deliveryManager.OrderCreated -= AddOrder;
        _deliveryManager.OrderCompleted -= RemoveOrder;
    }

    private void AddOrder(Order order)
    {
        OrderUI newOrder = Instantiate(_orderPrefab, _ordersContainer);
        newOrder.Construct(order.RecipeSO.Name, order.RecipeSO.Ingredients);
        _orders.Add(newOrder);  
    }

    private void RemoveOrder(Order inputOrder)
    {
        OrderUI orderToRemove = _orders.Where((order) => order.DishName == inputOrder.RecipeSO.Name).FirstOrDefault();
        _orders.Remove(orderToRemove);
        Destroy(orderToRemove.gameObject);
    }
}
