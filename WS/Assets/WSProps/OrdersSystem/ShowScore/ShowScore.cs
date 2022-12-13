using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] List<TextMesh> tm;
    [SerializeField] OrderManager om;

    private void Awake()
    {
        om.onUpdate.AddListener(UpdateMsh);
        UpdateMsh();
    }

    void UpdateMsh()
    {
        print("Updated");
        for(int i = 0; i < tm.Count; i++)
        {
            tm[i].text = om.GetScore().ToString();
        }
    }
}
