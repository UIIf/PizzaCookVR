using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RawPizzaScript : MonoBehaviour
{
    // время приготовления пиццы
    [SerializeField] float backeTime;
    [SerializeField] Material bakedMat;
    [SerializeField] MeshRenderer mr;

    [SerializeField] Material startMat;


    // Список использованных слоев пиццы
    List<IngLayer> ings = new List<IngLayer>();
    List<IngType> types = new List<IngType>();

    // Переменная отвечающая за процесс приготовления
    float backeProcess = 0f;

    private void OnCollisionStay(Collision collision)
    {
        // Достается компонент в котором хранятся характеристики ингредиента
        IngRidScript ing = collision.gameObject.GetComponent<IngRidScript>();

        // Если объект не является ингредиентом
        if (ing == null)
            return; // Выходим из программы

        // Если объект нельзя использовать
        if (!ing.processable)
            return; // Выходим из программы
        // Если ингредиент в руке
        if (collision.gameObject.GetComponent<Interactable>().attachedToHand != null)
            return; // Выходим из программы

        // Если ингредиент движется
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude > 0.2)
            return; // Выходим из программы

        // Определяется слой на котором лежит новый ингредиент
        IngLayer new_id = ing.GetLayer();

        // Если ингредиент такого типа уже есть
        if (ings.Contains(new_id))
            return; // Выходим из программы


        // Добавления нового ингредиента
        ings.Add(new_id);

        types.Add(ing.GetIngType());

        // Создание отображения нового ингредиента
        Instantiate(ing.GetNewMesh(), transform);
        // Удаление старого ингредиентся
        Destroy(collision.gameObject);
    }

    public void AddTime(float t)
    {
        backeProcess += t;

        
        if (backeProcess < backeTime)
            return;



        mr.material = bakedMat;
        ReadyPizza rp = gameObject.AddComponent<ReadyPizza>();
        rp.SetIngrids(types);


        Destroy(gameObject.GetComponent<RawPizzaScript>());
    }

}
