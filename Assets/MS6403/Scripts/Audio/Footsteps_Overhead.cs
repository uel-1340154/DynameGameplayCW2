using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Footsteps_Overhead : MonoBehaviour {

	public AudioClip[]	m_footstepClips;
	public float		m_fDistancePerStep = 0.2f;

	private Vector3		m_v3PositionLastStep;

	private AudioSource	m_audioSource;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource> ();

		m_v3PositionLastStep = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		float fDistance = Vector3.Distance (transform.position, m_v3PositionLastStep);
		if (fDistance > m_fDistancePerStep) {
			AudioClip clipToPlay;

			do
			{
				clipToPlay = m_footstepClips[Random.Range (0, m_footstepClips.Length-1)];
			}
			while (clipToPlay == m_audioSource.clip);

			m_audioSource.clip = clipToPlay;
			m_audioSource.Play ();

			m_v3PositionLastStep = transform.position;
		}
	}
}
