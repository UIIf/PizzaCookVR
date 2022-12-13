using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newOrder", menuName = "Orders/NewOrder")]
public class OrderSO : ScriptableObject
{
    [SerializeField] List<IngType> ingrids;

    [SerializeField] string Name;
    [SerializeField] string[] coments;
    [SerializeField] int points = 100;

    public string GetIng()
    {
        string ret = "";
        for (int i = 0; i < ingrids.Count; i++)
        {
            ret += ingrids[i].ToString() +"\n";
        }

        return ret;
    }

    public List<IngType> GetListIngs()
    {
        return ingrids;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetComment()
    {
        return coments[Random.Range(0, coments.Length)];
    }

    public int GetPoints()
    {
        return points;
    }
}
