using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngLayer
{
    low,
    mid,
    up
}

public enum IngType
{
    tomato,
    sausage,
    cheese,
    mushroom
}


public class IngRidScript : MonoBehaviour
{
    // Отображение ингредиента на пицце
    [SerializeField] GameObject newMesh;
    [SerializeField] IngType ingType;

    // Слой ингредиента
    [SerializeField] IngLayer id;

    public bool processable = true;

    // Получение отображения на пицце
    public GameObject GetNewMesh()
    {
        return newMesh;
    }

    // Получение слоя ингредиента
    public IngLayer GetLayer()
    {
        return id;
    }

    public IngType GetIngType()
    {
        return ingType;
    }
}
