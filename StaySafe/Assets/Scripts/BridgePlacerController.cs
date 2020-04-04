﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlacerController : MonoBehaviour
{
    public GameObject matchingBridge = null;
    public GameObject bridgePlaced = null;
    public GameObject bridgeBlocker = null;
    public EventScriptInterface optionalEventScript = null;
    public bool execSelfHide = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GameObject.ReferenceEquals(matchingBridge,other.gameObject))
        {
            ChesterAILerp lerper = other.gameObject.GetComponent<ChesterAILerp>();
            if (lerper != null && lerper.canMove)
            {
                lerper.DisableNavigation();
                other.gameObject.SetActive(false);
                //Play VFX Animation Here
                if(optionalEventScript != null)
                {
                    optionalEventScript.SomethingHappensHere();
                }
                if (execSelfHide)
                {
                    SelfHide();
                }
            }
        }
    }


    private void SelfHide()
    {
        bridgePlaced.SetActive(true);
        bridgeBlocker.SetActive(false);
        AstarPath.active.Scan();
    }
}
