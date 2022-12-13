using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class IngGenScript : MonoBehaviour
{
    [SerializeField] Transform spawnerPoint;
    [SerializeField] GameObject ing;
    [SerializeField] float timeToSpawn = 3f;

    GameObject spawned;
    private void Awake()
    {
        Spawn();
    }

    void Spawn()
    {
        spawned = Instantiate(ing, spawnerPoint);
        spawned.transform.localScale = new Vector3(
            1 / transform.lossyScale.x,
            1 / transform.lossyScale.y,
            1 / transform.lossyScale.z);
        spawned.GetComponent<Rigidbody>().isKinematic = true;
        Throwable thr = spawned.GetComponent<Throwable>();
        ProgIngrid pr = spawned.GetComponent<ProgIngrid>();
        if(pr != null)
        {
            pr.processable = false;
        }

        IngRidScript ingS = spawned.GetComponent<IngRidScript>();
        if (ingS != null)
        {
            ingS.processable = false;
        }

        thr.onPickUp.AddListener(Detech);
    }

    private void Detech()
    {
        Throwable thr = spawned.GetComponent<Throwable>();
        thr.onPickUp.RemoveListener(Detech);
        spawned.GetComponent<Rigidbody>().isKinematic = false;

        ProgIngrid pr = spawned.GetComponent<ProgIngrid>();
        if (pr != null)
        {
            pr.processable = true;
        }

        IngRidScript ingS = spawned.GetComponent<IngRidScript>();
        if (ingS != null)
        {
            ingS.processable = true;
        }

        StartCoroutine(SpawnNew());
    }

    IEnumerator SpawnNew()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Spawn();
        yield break;
    }
}
