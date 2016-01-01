using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DG_SimpleCharacter_Footsteps : MonoBehaviour {

	// The AudioClips to play for footsteps
	public AudioClip[]	m_footstepClips;

	// The distance that the player has to travel before swapping to a new sound
	public float		m_fDistancePerStep = 1.3f;

	// Use this for initialization
	void Start () {
		// Cache my audiosource
		m_audioSource = GetComponent<AudioSource> ();

		// Set my last position to this position
		m_v3PositionLastStep = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Calculate the distance from where I was to the last position of a footstep
		float fDistance = Vector3.Distance (transform.position, m_v3PositionLastStep);

		// If that distance is greater than the distance I travel to trigger a new clip, 
		// I make a new sound
		if (fDistance > m_fDistancePerStep) {

			// While the random clip I've chosen is the same as the one I've just played, pick a new random one.
			// This prevents us getting the same sound twice in a row.
			AudioClip clipToPlay;

			do
			{
				clipToPlay = m_footstepClips[Random.Range (0, m_footstepClips.Length-1)];
			}
			while (clipToPlay == m_audioSource.clip);

			// Just play our clip
			m_audioSource.clip = clipToPlay;
			m_audioSource.Play ();

			// And reset our last position for the next loop around.
			m_v3PositionLastStep = transform.position;
		}
	}

	// Draw debug gizmos
	void OnDrawGizmos()
	{
		// Gizmo color to yellow
		Gizmos.color = Color.yellow;

		// Draw a sphere of the radius of our footstep change
		Gizmos.DrawWireSphere (transform.position, m_fDistancePerStep);
	}

	// The position I was at on my last footstep
	private Vector3		m_v3PositionLastStep;

	// My cached audiosource
	private AudioSource	m_audioSource;
}
