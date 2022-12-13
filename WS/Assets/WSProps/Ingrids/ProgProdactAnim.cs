using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgProdactAnim : MonoBehaviour
{
    // Конечный размер
    [SerializeField] Vector3 endScale;
    // Кривая изменения размера
    [SerializeField] AnimationCurve curve;

    ProgIngrid prIng;

    Vector3 startScale;
    private void Awake()
    {
        // Получение измененеия общего размера изначального продукта
        startScale = Vector3.Scale(transform.localScale, new Vector3(
            1 / transform.lossyScale.x,
            1 / transform.lossyScale.y,
            1 / transform.lossyScale.z
            ));
        // Отскалированное последнее измерение
        endScale = Vector3.Scale(endScale, startScale);
        prIng = GetComponent<ProgIngrid>();
    }

    //Анимирование изменения продукта
    public void Animate()
    {
        transform.localScale = Vector3.Lerp(startScale, endScale, curve.Evaluate(prIng.GetPers()));
    }
}
