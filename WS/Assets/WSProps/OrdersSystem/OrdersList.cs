using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newOrderList", menuName = "Orders/NewOrderList")]
public class OrdersList : ScriptableObject
{
    [SerializeField] List<OrderSO> orders;

    public OrderSO GetOrder()
    {
        return orders[Random.Range(0, orders.Count)];
    }
}
