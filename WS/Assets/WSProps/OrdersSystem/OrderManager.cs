using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderManager : MonoBehaviour
{
    [SerializeField] List<GameObject> orderPlaces;
    [SerializeField] OrdersList oList;
    [SerializeField] GameObject oNotes;
    [SerializeField] int Points = 0;

    public UnityEvent onUpdate;

    List<OrderSO> orders;
    private void Awake()
    {
        // Список заказов
        orders = new List<OrderSO>();

        // Для каждого заказа
        for(int i = 0; i < orderPlaces.Count; i++)
        {
            // Добавления нового заказа
            orders.Add(oList.GetOrder());

            // Добавление заметки с заказом
            Instantiate(oNotes, orderPlaces[i].transform).GetComponent<OrderNote>().FillNote(orders[i]);
            
        }
    }

    // Провекрка пиццы на необходимость
    public bool CheckPizza(ReadyPizza rp)
    {
        // Список ингредиентов пицца
        List<IngType> ings = rp.GetIngrids();

        // Для каждого заказа
        for(int i = 0; i < orderPlaces.Count; i++)
        {
            // Список ингредиентов заказа
            List<IngType> orderIngs = orders[i].GetListIngs();
            // Число ингредиентов не совпадает
            if (ings.Count != orderIngs.Count)
                continue;

            // Все ингредиенты нужны в заказе
            bool allIngsCorrect = true;

            // Проверка наличия каждого ингредиента
            for(int ing = 0; ing < ings.Count && allIngsCorrect; ing++)
            {
                // Если ингредиента нет в заказе
                if (!orderIngs.Contains(ings[ing]))
                    allIngsCorrect = false;
            }

            // Если заказ выполнен
            if (allIngsCorrect)
            {
                OrderReady(i);
                return true;
            }
        }
        return false;
    }

    // Выполнение заказа
    private void OrderReady(int index)
    {
        
        // Начисление очков за приготовление
        Points += orders[index].GetPoints();
        onUpdate.Invoke();
        // Удаление записка
        Destroy(orderPlaces[index].transform.GetChild(0).gameObject);

        // Новый заказ
        orders[index] = oList.GetOrder();
        // Новая записка
        Instantiate(oNotes, orderPlaces[index].transform).GetComponent<OrderNote>().FillNote(orders[index]);
    }

    public int GetScore()
    {
        return Points;
    }

}
