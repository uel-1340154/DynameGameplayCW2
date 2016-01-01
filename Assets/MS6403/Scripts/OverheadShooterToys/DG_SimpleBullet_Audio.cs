using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DG_SimpleBullet_Audio : MonoBehaviour {

	public AudioClip[]	m_audioClips;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// this message is spawned by the firing code!
	void FireBullet()
	{
		// Check if we have any audio clips set up
		if (m_audioClips.GetLength (0) > 0)
			return;

		// Pick a random one to play
		AudioClip clipToPlay = m_audioClips [Random.Range (0, m_audioClips.Length)];
	
		// Play it
		m_audioSource.clip = clipToPlay;
		m_audioSource.Play ();
	}

	// Our audio source
	private AudioSource	m_audioSource;
}
