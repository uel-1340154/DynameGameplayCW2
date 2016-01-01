using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DG_Announcer : MonoBehaviour {

    // Audio clips to play at various stages of the game
	public AudioClip		m_readyClip;
	public AudioClip		m_goClip;
	public AudioClip		m_hurryUpClip;

	// Use this for initialization
	void Start () {

        //  Cache our audiosource
		m_audioSource = GetComponent<AudioSource> ();

        // Set up our message listeners - broadcast by our Director
		Messenger.AddListener ("PreGame_GetReady", PlayGetReady);
		Messenger.AddListener ("PreGame_Go", PlayGo); 
		Messenger.AddListener ("InGame_HurryUp", PlayHurryUp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Play our Get Ready AudioClip
	void PlayGetReady()
	{
		m_audioSource.PlayOneShot (m_readyClip);
	}

    // Play our Go Audioclip
	void PlayGo()
	{
		m_audioSource.PlayOneShot (m_goClip);
	}

    // Play our Hurry Up Audioclip
	void PlayHurryUp()
	{
		m_audioSource.PlayOneShot (m_hurryUpClip);
	}

    // Cache our audio source
    private AudioSource m_audioSource;
}
