using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioClip music;
    void OnTriggerEnter2D(Collider2D col)
    {
        SoundManager.Instance.PlayMusic(music);
        Destroy(this);
    }
}
