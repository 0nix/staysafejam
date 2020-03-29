using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScaleController : MonoBehaviour
{
    private List<HeartWeight> currentCollisions = new List<HeartWeight>();
    public int totalWeightNeeded = 100;
    public int currentWeight = 0;
    private bool puzzleSolved = false;
    public EventScriptInterface onSolve = null;
    void FixedUpdate()
    {    
        if (!puzzleSolved)
        {
            if(currentWeight >= totalWeightNeeded)
            {
                CompletePuzzle();
                puzzleSolved = true;
            }
        }
    }

    private void CompletePuzzle()
    {
        if(onSolve != null)
        {
            onSolve.SomethingHappensHere();
        }
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("heartPiece"))
        {
            HeartWeight w = other.gameObject.GetComponent<HeartWeight>();
            if(w != null)
            {
                currentWeight += w.weight;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        HeartWeight w = col.gameObject.GetComponent<HeartWeight>();
        if (w != null)
        {
            currentWeight -= w.weight;
        }
    }
}
