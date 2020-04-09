using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGrabFailure : EventScriptInterface
{
    public Animation playNotification = null;
    public SoundManager manager;
    public override void SomethingHappensHere()
    {
        if(playNotification != null)
        {
            playNotification.Rewind();
            playNotification.Play();
        }
        if (manager != null)
        {
            manager.PlaySFX(SoundManager.SoundSFX.TooHeavy);
        }

    }
}
