using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType
{
    knife,
    pin
}

public class ToolScript : MonoBehaviour
{
    // Type of the tool
    [SerializeField] ToolType type = ToolType.knife;
    [SerializeField] AudioSource src;
    //Return tool type
    public ToolType GetType()
    {
        return type;
    }

    public void Play(AudioClip ac)
    {
        print("Played");
        src.PlayOneShot(ac);
    }

}
