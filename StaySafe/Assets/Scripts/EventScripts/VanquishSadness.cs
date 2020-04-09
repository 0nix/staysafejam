using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanquishSadness : EventScriptInterface
{
    public SoundManager sound = null;
    public Animation clip = null;

    public override void SomethingHappensHere()
    {
        if(sound != null)
        {
            sound.PlaySFX(SoundManager.SoundSFX.BarrierDestroy);
            StartCoroutine(waitr());
        }

        IEnumerator waitr()
        {
            /*if(clip != null)
            {
                clip.Rewind();
                clip.Play();
            }*/
            yield return new WaitForSecondsRealtime(0.5f);
            this.transform.gameObject.SetActive(false);
        }
    }
}
