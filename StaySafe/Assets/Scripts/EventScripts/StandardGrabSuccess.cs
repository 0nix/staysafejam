using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGrabSuccess : EventScriptInterface
{
    public SoundManager manager;
    public override void SomethingHappensHere()
    {
        if(manager != null)
        {
            manager.PlaySFX(SoundManager.SoundSFX.Pickup);
        }

    }
}
