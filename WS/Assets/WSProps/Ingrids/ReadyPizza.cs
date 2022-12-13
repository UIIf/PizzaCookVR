using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPizza : MonoBehaviour
{
    // Список ингредиентов в пицце
    List<IngType> types = new List<IngType>();

    // Задать ингредиенты
    public void SetIngrids(List<IngType> i)
    {
        types = i;
    }

    // Получить ингредиент
    public List<IngType> GetIngrids()
    {
        return types;
    }
}
