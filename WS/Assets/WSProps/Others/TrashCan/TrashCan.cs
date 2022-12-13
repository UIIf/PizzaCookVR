using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TrashCan : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        // Получаем компонент пищи

        ReadyPizza rp = collision.gameObject.GetComponent<ReadyPizza>();
        IngRidScript ing = collision.gameObject.GetComponent<IngRidScript>();
        ProgIngrid prg = collision.gameObject.GetComponent<ProgIngrid>();
        RawPizzaScript rawP = collision.gameObject.GetComponent<RawPizzaScript>();

        // Если объект не пища
        if (rp == null && ing == null && prg == null && rawP == null)
            return;
        
        // Объект в руке
        if (collision.gameObject.GetComponent<Interactable>().attachedToHand != null)
            return; // Выходим из программы

        // Если объект движется
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude > 0.2f)
            return; // Выходим из программы

        Destroy(collision.gameObject);
    }
}
