using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesterJoin : EventScriptInterface
{
    public ChesterAILerp[] chestersJoining = null;
    public InputManager ManagerRef = null;

    public override void SomethingHappensHere()
    {
       
        if (ManagerRef != null)
        {
            //play vfx here
            foreach (ChesterAILerp c in chestersJoining)
            {
                ManagerRef.chester.Add(c);
                c.EnableNavigation();
            }
        }

    }
}
