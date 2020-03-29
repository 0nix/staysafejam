using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScriptInterface : MonoBehaviour
{
    public virtual void SomethingHappensHere()
    {
        Debug.Log("Something Happens Here");
    }
}
