using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBandaidFailureScript : EventScriptInterface
{
    public ChesterAILerp chesterToRecruit = null;
    public InputManager ManagerRef = null;

    public override void SomethingHappensHere()
    {
        if(ManagerRef != null)
        {
            //play vfx here
            ManagerRef.chester.Add(chesterToRecruit);
            chesterToRecruit.EnableNavigation();
        }
       
    }
}
