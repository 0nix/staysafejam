using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public InputManager manager = null;
    public Animation LogoAnimation = null;
    public Animation CreditsAnimation = null;
    public Animation ButtonAnimation = null;
    public Animation PanelAnimation = null;
    public GameObject StartCanvasRef = null;
    // Start is called before the first frame update
    public void StartGame()
    {    
        LogoAnimation.Play();
        CreditsAnimation.Play();
        ButtonAnimation.Play();
        PanelAnimation.Play();
        StartCoroutine(waitr());
    }

    IEnumerator waitr()
    {
        yield return new WaitForSecondsRealtime(1);
        manager.EnableControls();
        Cursor.visible = false;
        manager.inGame = true;
        StartCanvasRef.SetActive(false);

    }
}
