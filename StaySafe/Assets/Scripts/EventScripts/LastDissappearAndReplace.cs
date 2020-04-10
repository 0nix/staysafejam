using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDissappearAndReplace : DissappearAndReplace
{
    public Animation fadeInEndScreen = null;
    public InputManager input;
    public GameObject endScreen = null;

    public override void SomethingHappensHere()
    {
        if (cloud != null)
        {
            cloud.PlaceAndAnimate((cloudPlacer != null) ? cloudPlacer.transform : gameObject.transform);
        }

        foreach (GameObject go in hideObjects)
        {
            if (go.GetComponent<GrabbableController>() != null)
            {
                go.GetComponent<GrabbableController>().OnRelease();
            }
            go.SetActive(false);
        }

        foreach (GameObject go in showObjects)
        {
            go.SetActive(true);
        }
        if (finishingSFX && soundManager != null)
        {
            if (barrierSFX)
            {
                soundManager.PlaySFX(SoundManager.SoundSFX.BarrierDestroy);
            }
            else
            {
                soundManager.PlaySFX(SoundManager.SoundSFX.Connect);
            }
        }
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSecondsRealtime(6f);
        input.inGame = false;
        endScreen.SetActive(true);
        fadeInEndScreen.Rewind();
        fadeInEndScreen.Play();
        yield return new WaitForSecondsRealtime(5f);
        input.EndScreenControls();
    }
}
