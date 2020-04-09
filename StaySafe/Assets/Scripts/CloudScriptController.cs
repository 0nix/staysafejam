using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScriptController : MonoBehaviour
{
    public Animation anim = null;

    public void PlaceAndAnimate(Transform position)
    {
        this.transform.SetPositionAndRotation(position.position, Quaternion.identity);
        if(anim != null)
        {
            anim.Rewind();
            anim.Play();
        }
    }
}
