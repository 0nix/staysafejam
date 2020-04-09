using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlacerController : MonoBehaviour
{
    public GameObject matchingBridge = null;
    public GameObject bridgePlaced = null;
    public GameObject bridgeBlocker = null;
    public EventScriptInterface optionalEventScript = null;
    public bool execSelfHide = true;
    public SoundManager manager = null;
    public CloudScriptController cloud = null;
    public GameObject cloudPlacer = null;

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
                other.gameObject.GetComponent<GrabbableController>().OnRelease();
                if(cloud != null)
                {
                    cloud.PlaceAndAnimate((cloudPlacer != null) ? cloudPlacer.transform : gameObject.transform);
                }
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
        if(manager != null)
        {
            manager.PlaySFX(SoundManager.SoundSFX.BandaidPlaced);
        }
    }
}
