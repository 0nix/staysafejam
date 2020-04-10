using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioClip music;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        ChesterAILerp lerper = other.gameObject.GetComponent<ChesterAILerp>();
        if (lerper == null) return;
        if (!lerper.canMove) return;
        SoundManager.Instance.PlayMusic(music);
        Destroy(this);

    }
}

