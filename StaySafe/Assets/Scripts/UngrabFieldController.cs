using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UngrabFieldController : MonoBehaviour
{
    public string UngrabThisTag = "grabbable";
    public Transform dropOff = null;
    
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
        
        if (other.gameObject.CompareTag(UngrabThisTag))
        {
            ChesterAILerp lerper = other.gameObject.GetComponent<ChesterAILerp>();
            if(lerper != null)
            {
                lerper.DisableNavigation();
                Vector3 drop = dropOff.position;
                other.gameObject.transform.SetPositionAndRotation(drop, Quaternion.identity);
            }
        }
    }
}
