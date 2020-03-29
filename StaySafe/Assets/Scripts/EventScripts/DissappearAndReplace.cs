using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearAndReplace : EventScriptInterface
{
    public GameObject[] hideObjects = null;
    public GameObject[] showObjects = null;

    public override void SomethingHappensHere()
    {
        foreach (GameObject go in hideObjects)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in showObjects)
        {
            go.SetActive(true);
        }
        AstarPath.active.Scan();

    }
}
