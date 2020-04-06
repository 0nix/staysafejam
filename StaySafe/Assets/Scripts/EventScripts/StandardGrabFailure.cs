using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGrabFailure : EventScriptInterface
{
    public Animation playNotification = null;

    public override void SomethingHappensHere()
    {
        Debug.Log("Failed to grab");
        if(playNotification != null)
        {
            playNotification.Rewind();
            playNotification.Play();
        }

    }
}
