using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerController : MonoBehaviour
{
    public EventScriptInterface eventScript = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool objcanMove = other.gameObject.GetComponent<ChesterAILerp>().canMove;
        if (!objcanMove) return;
        if (eventScript != null)
        {
            eventScript.SomethingHappensHere();
        }

    }
}
