using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGrabFailure : EventScriptInterface
{
    public override void SomethingHappensHere()
    {
        Debug.Log("Failed to grab");

    }
}
