using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BakeScript : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;



    private void OnTriggerStay(Collider other)
    {
        
        RawPizzaScript rps = other.gameObject.GetComponent<RawPizzaScript>();
        if (rps == null)
            return;
        rps.AddTime(Time.deltaTime);

    }
}
