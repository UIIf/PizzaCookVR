using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OutputWindowScript : MonoBehaviour
{
    [SerializeField] OrderManager om;

    private void OnTriggerStay(Collider other)
    {
        // Получаем компонент пиццы
        ReadyPizza rp = other.gameObject.GetComponent<ReadyPizza>();

        // Если объект не пицца
        if (rp == null)
            return; // Выходим из программы

        // Пицца в руке
        if (other.gameObject.GetComponent<Interactable>().attachedToHand != null)
            return; // Выходим из программы

        // Если пицца движется
        if (other.GetComponent<Rigidbody>().velocity.sqrMagnitude > 0.2f)
            return; // Выходим из программы
        
        // Проверка, нужна ли такая пицца
        if(om.CheckPizza(rp))
            Destroy(other.gameObject);// Удаление пицца
    }
}
