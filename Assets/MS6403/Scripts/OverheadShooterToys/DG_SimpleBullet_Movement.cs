using UnityEngine;
using System.Collections;

public class DG_SimpleBullet_Movement : MonoBehaviour {

	// Movement speed
	public float	m_fMovementSpeed = 0.3f;
	// How far to travel before I die
	public float	m_fMaxTravelDistance = 80.0f;

	// Use this for initialization
	void Start () {
	}

	// We do this here to make use of the pooling system
	void OnEnable()
	{
		// Reset distance
		m_fTravelledDistance = 0.0f;
	}


	// Update is called once per frame
	void Update () {
		// Move us
		transform.Translate (Vector3.forward * m_fMovementSpeed * Time.deltaTime);	

		// Check how far we've gone
		m_fTravelledDistance += m_fMovementSpeed * Time.deltaTime;

		// If we've hit our max distance, we can destroy ourselves
		if (m_fTravelledDistance > m_fMaxTravelDistance) {
			gameObject.DestroyAPS();		// Assumes we're using our pooling system
		}
	}

	// Keep track of how far we've travelled
	private float	m_fTravelledDistance;
}
