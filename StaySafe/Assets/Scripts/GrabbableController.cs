﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableController : MonoBehaviour
{
    private List<GameObject> currentCollisions = new List<GameObject>();
    public bool isGrabbed = false;
    public EventScriptInterface SuccessEventScript = null;
    public EventScriptInterface FailureEventScript = null;
    public int chesterRequirement = 0;
    private ChesterAILerp ChesterLerp;
    // Start is called before the first frame update
    void Start()
    {
        ChesterLerp = GetComponentInParent<ChesterAILerp>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnGrab()
    {

    }

    public virtual void OnRelease()
    {

    }
    public void AttemptGrabToggle(GameObject projectedCursor)
    {
        if (!isGrabbed)
        {
            if (chesterRequirement <= currentCollisions.Count)
            {
                isGrabbed = true;
                ChesterLerp.EnableNavigation();
                OnGrab();
                if(SuccessEventScript != null)
                {
                    SuccessEventScript.SomethingHappensHere();
                }
            }
            else
            {
                if (FailureEventScript != null)
                {
                    FailureEventScript.SomethingHappensHere();
                }
            }
        } else
        {
            isGrabbed = false;
            ChesterLerp.DisableNavigation();
            OnRelease();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("chester") && !currentCollisions.Contains(other.gameObject))
        {
            currentCollisions.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (currentCollisions.Contains(col.gameObject))
        {
            currentCollisions.Remove(col.gameObject);
        }

       
    }
}
