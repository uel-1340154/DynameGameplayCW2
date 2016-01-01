using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DG_SimpleEnemy_Audio : MonoBehaviour {

	public AudioClip		m_playerSpottedClip;
	public AudioClip		m_playerMovingClip;
	public AudioClip		m_characterBulletHit;

	private AudioSource		m_audioSource;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Methods from the State Machine to trigger sounds
	public void PlayerSpotted()
	{
		if (m_playerSpottedClip != null) {
			m_audioSource.PlayOneShot (m_playerSpottedClip);
		}
	}

	public void PlayerMoving()
	{
		if (m_playerMovingClip != null) {
			if (m_audioSource.isPlaying != true)
			{
				m_audioSource.clip = m_playerMovingClip;
				m_audioSource.Play ();
			}
		}
	}

	public void HitByBullet()
	{
		if (m_characterBulletHit) {
			m_audioSource.PlayOneShot (m_characterBulletHit);
		}

	}
}
