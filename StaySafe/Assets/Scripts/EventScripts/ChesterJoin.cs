using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesterJoin : EventScriptInterface
{
    public ChesterAILerp[] chestersJoining = null;
    public InputManager ManagerRef = null;
    public SoundManager SoundManager = null;


    public override void SomethingHappensHere()
    {
       
        if (ManagerRef != null)
        {
            //play vfx here
            foreach (ChesterAILerp c in chestersJoining)
            {
                if (!ManagerRef.chester.Contains(c)) {
                    ManagerRef.chester.Add(c);
                    c.EnableNavigation();
                    if (SoundManager != null)
                    {
                        SoundManager.PlaySFX(SoundManager.SoundSFX.Activated);
                    }
                }
            }
        }
        

    }
}
