using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public enum SoundSFX
    {
        Activated,
        Drop,
        Hup,
        Pickup,
        TooHeavy,
        BarrierDestroy,
        BandaidPlaced,
        Connect
    };
    
    // Audio players components.
	public AudioClip[] ChestersActivated;
    public AudioClip[] chestersDrop;
    public AudioClip[] chesterHup;
    public AudioClip[] chesterPickup;
    public AudioClip[] chesterTooHeavy;
    public AudioClip[] connect;
    public AudioClip BarrierDestroy;
    public AudioClip BandaidPlaced;
	public AudioSource MusicSource;
    public AudioSource EffectsSource;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

    public void PlaySFX(SoundSFX code)
    {
        switch (code)
        {
            case SoundSFX.Activated:
                RandomSoundEffect(ChestersActivated);
                break;
            case SoundSFX.BandaidPlaced:
                StartCoroutine(Play(BandaidPlaced));
                break;
            case SoundSFX.BarrierDestroy:
                StartCoroutine(Play(BarrierDestroy));
                break;
            case SoundSFX.Drop:
                RandomSoundEffect(chestersDrop);
                break;
            case SoundSFX.TooHeavy:
                RandomSoundEffect(chesterTooHeavy);
                break;
            case SoundSFX.Hup:
                RandomSoundEffect(chesterHup);
                break;
            case SoundSFX.Pickup:
                RandomSoundEffect(chesterHup);
                break;
            case SoundSFX.Connect:
                RandomSoundEffect(connect);
                break;
        }
    }

	// Play a single clip through the sound effects source.
	public IEnumerator Play(AudioClip clip)
	{
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clip;
		EffectsSource.Play();
        yield return new WaitForSeconds(clip.length);
    }

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();

	}

	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
        StartCoroutine(Play(clips[randomIndex]));
	}

	//Play 


}