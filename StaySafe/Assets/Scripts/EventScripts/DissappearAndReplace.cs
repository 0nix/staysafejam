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
    public CloudScriptController cloud = null;
    public GameObject cloudPlacer = null;
    public override void SomethingHappensHere()
    {
        if (cloud != null)
        {
            cloud.PlaceAndAnimate((cloudPlacer != null) ? cloudPlacer.transform : gameObject.transform);
        }

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
