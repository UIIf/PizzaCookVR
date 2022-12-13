using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
enum CookingType
{
    hold,
    hit
}

public class ProgIngrid : MonoBehaviour
{
    [SerializeField] AudioClip hit;
    // Время для приготовления ингредиента
    [SerializeField] float cookingTime = 3f;
    // Тип инструмента для приготовления
    [SerializeField] ToolType toolType = ToolType.knife;

    // Способ готовки
    [SerializeField] CookingType type = CookingType.hit;

    // Приготовленный ингредиент
    [SerializeField] GameObject newPref;

    [SerializeField] UnityEvent onChangeProg;

    // Скрипт для проверки, находится ли объект в руке
    Interactable intr;
    // Процесс приготовления
    float curTime = 0;

    public bool processable = true;

    private void Awake()
    {
        // Достается ингредиент
        intr = GetComponent<Interactable>();
    }

    // При пересечении колайдеров
    private void OnCollisionEnter(Collision collision)
    {
        if (!processable)
            return;
        // Если объект в руке
        if (intr.attachedToHand != null)
            return; // Заканчиваем программу

        // Если тип готовки не подходит
        if (type != CookingType.hit)
            return; // Заканчиваем программу

        // Достаем скрипт инструменат
        ToolScript ts = collision.gameObject.GetComponent<ToolScript>();
        // Если нет скрипта инструмента
        if (ts == null)
            return; // Заканчиваем программу
        // Если тип инструмента не подходит
        if (ts.GetType() != ToolType.knife)
            return; // Заканчиваем программу

        ts.Play(hit);
        // Увеличение прогресса
        AddTime(1f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!processable)
            return;
        // Если объект в руке
        if (intr.attachedToHand != null)
            return;// Заканчиваем программу

        // Если тип готовки не подходит
        if (type != CookingType.hold) 
            return;// Заканчиваем программу

        // Достаем скрипт инструменат
        ToolScript ts = collision.gameObject.GetComponent<ToolScript>();
        // Если нет скрипта инструмента
        if (ts == null)
            return;// Заканчиваем программу
        // Если тип инструмента не подходит

        if (collision.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude < 0.2f)
            return;
        if (ts.GetType() != ToolType.pin)
            return;// Заканчиваем программу

        // Увеличение прогресса
        AddTime(Time.deltaTime);
    }

    void AddTime(float t)
    {
        // Увеличение прогресса
        curTime += t;
        onChangeProg.Invoke();
        // Если ингредиент приготовлен
        if (curTime >= cookingTime)
        {
            // Создание нового ингредиента
            Instantiate(newPref, transform.position, transform.rotation);
            //Удаление старого ингредиента
            Destroy(gameObject);
        }
    }

    public float GetPers()
    {
        return curTime / cookingTime;
    }
}
