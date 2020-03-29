using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlacerController : MonoBehaviour
{
    public string bridgeTag = null;
    public GameObject bridgePlaced = null;

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

        if (other.gameObject.CompareTag(bridgeTag))
        {
            ChesterAILerp lerper = other.gameObject.GetComponent<ChesterAILerp>();
            if (lerper != null)
            {
                lerper.DisableNavigation();
                other.gameObject.SetActive(false);
                //Play VFX Animation Here
                SelfHide();
            }
        }
    }


    private void SelfHide()
    {
        bridgePlaced.SetActive(true);
        gameObject.SetActive(false);
        AstarPath.active.Scan();
    }
}
