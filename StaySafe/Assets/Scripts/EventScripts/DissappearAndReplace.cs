using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearAndReplace : EventScriptInterface
{
    public GameObject[] hideObjects = null;
    public GameObject[] showObjects = null;
    public SoundManager soundManager = null;
    public bool finishingSFX = false;
    public bool barrierSFX = false;
    public override void SomethingHappensHere()
    {
        foreach (GameObject go in hideObjects)
        {
            if (go.GetComponent<GrabbableController>() != null)
            {
                go.GetComponent<GrabbableController>().OnRelease();
            }
            go.SetActive(false);
        }

        foreach (GameObject go in showObjects)
        {
            /*if(go.GetComponent<GrabbableController>() != null)
            {
                go.GetComponent<GrabbableController>().OnRelease();
            }*/
            go.SetActive(true);
        }
        AstarPath.active.Scan();
        if (finishingSFX && soundManager != null)
        {
            if (barrierSFX) {
                soundManager.PlaySFX(SoundManager.SoundSFX.BarrierDestroy);
            }
            else
            {
                soundManager.PlaySFX(SoundManager.SoundSFX.Connect);
            }
        }

    }
}
