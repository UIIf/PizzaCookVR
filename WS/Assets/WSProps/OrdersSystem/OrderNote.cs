using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNote : MonoBehaviour
{
    [SerializeField] TextMesh Name;
    [SerializeField] TextMesh ingrids;
    [SerializeField] TextMesh coment;

    public void FillNote(OrderSO order)
    {
        Name.text = order.GetName();
        coment.text = order.GetComment();
        ingrids.text = order.GetIng();
    }
}
