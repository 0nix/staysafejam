using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerController : MonoBehaviour
{
    public EventScriptInterface eventScript = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ChesterAILerp lerper = other.gameObject.GetComponent<ChesterAILerp>();
        if (lerper == null) return;
        if (!lerper.canMove) return;
        if (eventScript != null)
        {
            eventScript.SomethingHappensHere();
        }

    }
}
